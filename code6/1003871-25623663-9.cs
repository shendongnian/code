    [Test]
    public unsafe void TestMethod1()
    {
        int* any = stackalloc int[4];
        Mock<IMyUnsafeInterface> mockDependency = new Mock<IMyUnsafeInterface>();
        // use the mock
        mockDependency.Object.DoWork(any);
        mockDependency.Verify(p => p.DoWork(Is(any)));
    }
    [Matcher]
    public static unsafe int* Is(int* expected) { return null; }
    public static unsafe bool Is(int* actual, int* expected)
    {
        return actual == expected;
    }
