    public delegate void Test();
    // ...
    Test test = TestMethod;
    IL_0002: ldftn void testcs.Program::TestMethod()
    IL_0008: newobj instance void testcs.Program/Test::.ctor(object, native int)
