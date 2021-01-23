    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       116 (0x74)
      .maxstack  2
      .locals init (valuetype [mscorlib]System.Nullable`1<valuetype Test.Number> V_0,
               valuetype [mscorlib]System.Nullable`1<float64> V_1,
               valuetype [mscorlib]System.Nullable`1<valuetype Test.Number> V_2,
               valuetype [mscorlib]System.Nullable`1<float64> V_3,
               valuetype [mscorlib]System.Nullable`1<float64> V_4)
    // Number? b = 1.2;
      IL_0000:  nop
      IL_0001:  ldloca.s   V_0 //b
      IL_0003:  ldc.r8     1.2
      IL_000c:  call       valuetype Test.Number Test.Number::op_Implicit(float64)
      IL_0011:  call       instance void valuetype [mscorlib]System.Nullable`1<valuetype Test.Number>::.ctor(!0)
      IL_0016:  nop
      IL_0017:  ldloc.0
      IL_0018:  stloc.2    // b
    // var c = b - 1.2;
      IL_0019:  ldloca.s   V_2 // b
      IL_001b:  call       instance bool valuetype [mscorlib]System.Nullable`1<valuetype Test.Number>::get_HasValue()
      IL_0020:  brtrue.s   IL_002d
      IL_0022:  ldloca.s   V_3
      IL_0024:  initobj    valuetype [mscorlib]System.Nullable`1<float64>
      IL_002a:  ldloc.3
      IL_002b:  br.s       IL_003e
      IL_002d:  ldloca.s   V_2
      IL_002f:  call       instance !0 valuetype [mscorlib]System.Nullable`1<valuetype Test.Number>::GetValueOrDefault()
      IL_0034:  call       float64 Test.Number::op_Implicit(valuetype Test.Number)
      // Um, what? First part of compiler bug is that it's needlessly creating a nullable float
      IL_0039:  newobj     instance void valuetype [mscorlib]System.Nullable`1<float64>::.ctor(!0)
      IL_003e:  nop
      IL_003f:  stloc.3
      IL_0040:  ldloca.s   V_3
      IL_0042:  call       instance bool valuetype [mscorlib]System.Nullable`1<float64>::get_HasValue()
      IL_0047:  brtrue.s   IL_0055
      IL_0049:  ldloca.s   V_4
      IL_004b:  initobj    valuetype [mscorlib]System.Nullable`1<float64>
      IL_0051:  ldloc.s    V_4
      IL_0053:  br.s       IL_0071
      IL_0055:  ldloca.s   V_3
      
      // Here's the real bug, though.  It's passing float64 to a the op_Implicit that is expecting a Number struct
      IL_0057:  call       instance !0 valuetype [mscorlib]System.Nullable`1<float64>::GetValueOrDefault()
      IL_005c:  call       float64 Test.Number::op_Implicit(valuetype Test.Number)
      IL_0061:  conv.r8
      IL_0062:  ldc.r8     1.2
      IL_006b:  sub
      IL_006c:  newobj     instance void valuetype [mscorlib]System.Nullable`1<float64>::.ctor(!0)
      IL_0071:  nop
      IL_0072:  stloc.1
      IL_0073:  ret
    } // end of method Program::Main
