﻿module FSharp.Data.Tests.Conversions

#if INTERACTIVE
#r "../../bin/FSharp.Data.dll"
#r "../../packages/NUnit.2.6.3/lib/nunit.framework.dll"
#load "../Common/FsUnit.fs"
#endif

open NUnit.Framework
open FsUnit
open System.Globalization
open FSharp.Data.Runtime

[<Test>]
let ``Boolean conversions``() = 
  let asBoolean = TextConversions.AsBoolean CultureInfo.InvariantCulture

  asBoolean "yEs"  |> should equal (Some true)
  asBoolean "trUe" |> should equal (Some true)
  asBoolean "1"    |> should equal (Some true)

  asBoolean "nO"    |> should equal (Some false)
  asBoolean "faLSe" |> should equal (Some false)
  asBoolean "0"     |> should equal (Some false)

  asBoolean "rubbish" |> should equal None

[<Test>]
let ``Decimal conversions``() = 
  TextConversions.AsDecimal CultureInfo.InvariantCulture "¤50" |> should equal (Some 50M)
  TextConversions.AsDecimal (CultureInfo "en-GB") "£50" |> should equal (Some 50M)
  TextConversions.AsDecimal (CultureInfo "en-GB") "$50" |> should equal None
