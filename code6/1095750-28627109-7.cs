    //000017:         {
        IL_0000:  nop
    //000018:             A g = new A();
        IL_0001:  newobj     instance void ConsoleApplication1.A::.ctor()
        IL_0006:  stloc.0
    //000019:             Console.WriteLine(g.j);
        IL_0007:  ldloc.0
        IL_0008:  ldfld      int32 ConsoleApplication1.A::j
        IL_000d:  call       void [mscorlib]System.Console::WriteLine(int32)
        IL_0012:  nop
    //000020:         }
