    .method public hidebysig specialname rtspecialname 
        instance void  .ctor() cil managed
    // SIG: 20 00 01
    {
      // Method begins at RVA 0x2050
      // Code size       21 (0x15)
      .maxstack  8
      IL_0000:  /* 02   |                  */ ldarg.0
      IL_0001:  /* 1F   | 09               */ ldc.i4.s   9
      IL_0003:  /* 8D   | (01)000013       */ newarr     [mscorlib]System.Int32
      IL_0008:  /* 7D   | (04)000001       */ stfld      int32[] ConsoleApplication2.MyClass::myArray
      IL_000d:  /* 02   |                  */ ldarg.0
      IL_000e:  /* 28   | (0A)000011       */ call       instance void [mscorlib]System.Object::.ctor()
      IL_0013:  /* 00   |                  */ nop
      IL_0014:  /* 2A   |                  */ ret
