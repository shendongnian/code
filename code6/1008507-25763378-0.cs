    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       27 (0x1b)
      .maxstack  2
      .locals init ([0] string someText,
               [1] class [System]System.Text.RegularExpressions.Regex r,
               [2] class [System]System.Text.RegularExpressions.MatchCollection matchCollection)
      IL_0000:  nop
      IL_0001:  ldstr      "s"
      IL_0006:  stloc.0
      IL_0007:  ldstr      "example"
      IL_000c:  newobj     instance void [System]System.Text.RegularExpressions.Regex::.ctor(string)
      IL_0011:  stloc.1
      IL_0012:  ldloc.1
      IL_0013:  ldloc.0
      IL_0014:  callvirt   instance class [System]System.Text.RegularExpressions.MatchCollection [System]System.Text.RegularExpressions.Regex::Matches(string)
      IL_0019:  stloc.2
      IL_001a:  ret
    } // end of method Program::Main
