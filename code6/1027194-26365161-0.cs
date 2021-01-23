    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       55 (0x37)
      .maxstack  2
      .locals init ([0] string dateString0,
               [1] string dateString1)
      IL_0000:  ldstr      "The date: {0}"
      IL_0005:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
      IL_000a:  box        [mscorlib]System.DateTime
      IL_000f:  call       string [mscorlib]System.String::Format(string,
                                                                  object)
      IL_0014:  stloc.0
      IL_0015:  ldstr      "The date: "
      IL_001a:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
      IL_001f:  box        [mscorlib]System.DateTime
      IL_0024:  call       string [mscorlib]System.String::Concat(object,
                                                                  object)
      IL_0029:  stloc.1
      IL_002a:  ldloc.0
      IL_002b:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0030:  ldloc.1
      IL_0031:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0036:  ret
    } // end of method Program::Main
