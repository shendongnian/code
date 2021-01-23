    .method public hidebysig static void  TestHash() cil managed
    {
      // Code size       65 (0x41)
      .maxstack  2
      .locals init ([0] class [System.Core]System.Collections.Generic.HashSet`1<int32> foo,
               [1] int32 bar,
               [2] class [System.Core]System.Collections.Generic.HashSet`1<int32> '<>g__initLocal3',
               [3] valuetype [System.Core]System.Collections.Generic.HashSet`1/Enumerator<int32> CS$5$0000)
      IL_0000:  newobj     instance void class [System.Core]System.Collections.Generic.HashSet`1<int32>::.ctor()
      IL_0005:  stloc.2
      IL_0006:  ldloc.2
      IL_0007:  ldc.i4.1
      IL_0008:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<int32>::Add(!0)
      IL_000d:  pop
      IL_000e:  ldloc.2
      IL_000f:  stloc.0
      IL_0010:  ldloc.0
      IL_0011:  callvirt   instance valuetype [System.Core]System.Collections.Generic.HashSet`1/Enumerator<!0> class [System.Core]System.Collections.Generic.HashSet`1<int32>::GetEnumerator()
      IL_0016:  stloc.3
      .try
      {
        IL_0017:  br.s       IL_0027
        IL_0019:  ldloca.s   CS$5$0000
        IL_001b:  call       instance !0 valuetype [System.Core]System.Collections.Generic.HashSet`1/Enumerator<int32>::get_Current()
        IL_0020:  stloc.1
        IL_0021:  ldloc.1
        IL_0022:  call       void Test::NoOp(int32)
        IL_0027:  ldloca.s   CS$5$0000
        IL_0029:  call       instance bool valuetype [System.Core]System.Collections.Generic.HashSet`1/Enumerator<int32>::MoveNext()
        IL_002e:  brtrue.s   IL_0019
        IL_0030:  leave.s    IL_0040
      }  // end .try
      finally
      {
        IL_0032:  ldloca.s   CS$5$0000
        IL_0034:  constrained. valuetype [System.Core]System.Collections.Generic.HashSet`1/Enumerator<int32>
        IL_003a:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_003f:  endfinally
      }  // end handler
      IL_0040:  ret
    } // end of method Test::TestHash
    .method public hidebysig static void  TestIList() cil managed
    {
      // Code size       58 (0x3a)
      .maxstack  2
      .locals init ([0] class [mscorlib]System.Collections.Generic.IList`1<int32> foo,
               [1] int32 bar,
               [2] class [mscorlib]System.Collections.Generic.List`1<int32> '<>g__initLocal4',
               [3] class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> CS$5$0000)
      IL_0000:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
      IL_0005:  stloc.2
      IL_0006:  ldloc.2
      IL_0007:  ldc.i4.1
      IL_0008:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<int32>::Add(!0)
      IL_000d:  ldloc.2
      IL_000e:  stloc.0
      IL_000f:  ldloc.0
      IL_0010:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
      IL_0015:  stloc.3
      .try
      {
        IL_0016:  br.s       IL_0025
        IL_0018:  ldloc.3
        IL_0019:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>::get_Current()
        IL_001e:  stloc.1
        IL_001f:  ldloc.1
        IL_0020:  call       void Test::NoOp(int32)
        IL_0025:  ldloc.3
        IL_0026:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_002b:  brtrue.s   IL_0018
        IL_002d:  leave.s    IL_0039
      }  // end .try
      finally
      {
        IL_002f:  ldloc.3
        IL_0030:  brfalse.s  IL_0038
        IL_0032:  ldloc.3
        IL_0033:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0038:  endfinally
      }  // end handler
      IL_0039:  ret
    } // end of method Test::TestIList
    .method public hidebysig static void  TestArray() cil managed
    {
      // Code size       45 (0x2d)
      .maxstack  3
      .locals init ([0] int32[] foo,
               [1] int32 bar,
               [2] int32[] CS$0$0000,
               [3] int32[] CS$6$0001,
               [4] int32 CS$7$0002)
      IL_0000:  ldc.i4.1
      IL_0001:  newarr     [mscorlib]System.Int32
      IL_0006:  stloc.2
      IL_0007:  ldloc.2
      IL_0008:  ldc.i4.0
      IL_0009:  ldc.i4.1
      IL_000a:  stelem.i4
      IL_000b:  ldloc.2
      IL_000c:  stloc.0
      IL_000d:  ldloc.0
      IL_000e:  stloc.3
      IL_000f:  ldc.i4.0
      IL_0010:  stloc.s    CS$7$0002
      IL_0012:  br.s       IL_0025
      IL_0014:  ldloc.3
      IL_0015:  ldloc.s    CS$7$0002
      IL_0017:  ldelem.i4
      IL_0018:  stloc.1
      IL_0019:  ldloc.1
      IL_001a:  call       void Test::NoOp(int32)
      IL_001f:  ldloc.s    CS$7$0002
      IL_0021:  ldc.i4.1
      IL_0022:  add
      IL_0023:  stloc.s    CS$7$0002
      IL_0025:  ldloc.s    CS$7$0002
      IL_0027:  ldloc.3
      IL_0028:  ldlen
      IL_0029:  conv.i4
      IL_002a:  blt.s      IL_0014
      IL_002c:  ret
    } // end of method Test::TestArray
