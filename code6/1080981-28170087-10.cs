    .method public hidebysig static int32  Sum1(class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> source) cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       44 (0x2c)
      .maxstack  2
      .locals init ([0] int32 sum,
               [1] int32 v,
               [2] class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> CS$5$0000)
      IL_0000:  ldc.i4.0
      IL_0001:  stloc.0
      IL_0002:  ldarg.0
      IL_0003:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
      IL_0008:  stloc.2
      .try
      {
        IL_0009:  br.s       IL_0016
        IL_000b:  ldloc.2
        IL_000c:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>::get_Current()
        IL_0011:  stloc.1
        IL_0012:  ldloc.0
        IL_0013:  ldloc.1
        IL_0014:  add.ovf
        IL_0015:  stloc.0
        IL_0016:  ldloc.2
        IL_0017:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_001c:  brtrue.s   IL_000b
        IL_001e:  leave.s    IL_002a
      }  // end .try
      finally
      {
        IL_0020:  ldloc.2
        IL_0021:  brfalse.s  IL_0029
        IL_0023:  ldloc.2
        IL_0024:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0029:  endfinally
      }  // end handler
      IL_002a:  ldloc.0
      IL_002b:  ret
    } // end of method LinqExtension::Sum1
