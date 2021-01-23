    .method public hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      .maxstack  1
      .locals init (class Test.A V_0)
      IL_0001:  newobj     instance void Test.A::.ctor()
      IL_0006:  stloc.0
      IL_0007:  ret
    }
