    // Metadata version: v2.0.50727
    .assembly extern mscorlib
    {
      .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )            // .z\V.4..
      .ver 2:0:0:0
    }
    .assembly HelloCLR
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices...
      .custom instance void [mscorlib]System.Runtime.CompilerServices...
      .hash algorithm 0x00008004
      .ver 0:0:0:0
    }
    .module HelloCLR.exe
    // MVID: {14AAFB90-AC8E-4A34-84CB-1B9D2888C6E2}
    .imagebase 0x00400000
    .file alignment 0x00000200
    .stackreserve 0x00100000
    .subsystem 0x0003       // WINDOWS_CUI
    .corflags 0x00000001    //  ILONLY
    // Image base: 0x032C0000
    // =============== CLASS MEMBERS DECLARATION ===================
    .class private auto ansi beforefieldinit HelloCLR
       extends [mscorlib]System.Object
    {
     .method public hidebysig static void  Main() cil managed
     {
      .entrypoint
      // Code size       23 (0x17)
      .maxstack  8
      IL_0000:  nop
      IL_0001:  ldstr      "Hello CLR {0}!"
      IL_0006:  call       class [mscorlib]System.Version 
                          [mscorlib]System.Environment::get_Version()
      IL_000b:  callvirt   instance string 
                          [mscorlib]System.Object::ToString()
      IL_0010:  call       void [mscorlib]System.Console::WriteLine(
                          string, object)
      IL_0015:  nop
      IL_0016:  ret
     } // end of method HelloCLR::Main
     .method public hidebysig specialname rtspecialname 
         instance void  .ctor() cil managed
     {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
     } // end of method HelloCLR::.ctor
    } // end of class HelloCLR
    // =============================================================
    // *********** DISASSEMBLY COMPLETE ***********************
    // WARNING: Created Win32 resource file C:\herong\HelloCLR_dis.res
