    namespace ConsoleApplication1 {
      class Program {
        static void Main(string[] args) {
          short d = ("obj" == "obj") ? 1 : 2;
        }
      }
    }
    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
     // Code size       4 (0x4)
     .maxstack  1
     .locals init ([0] int16 d)
     IL_0000:  nop
     IL_0001:  ldc.i4.1
     IL_0002:  stloc.0
     IL_0003:  ret
     } // end of method Program::Main
