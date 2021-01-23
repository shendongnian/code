    private static readonly object[] TestCases =
    {
        new TestCaseData( A, B, C ).SetName("A B C"),
        new TestCaseData( C, A, B ).SetName("C A B"),
        new TestCaseData( C, B, A ).SetName("C B A")
    };
    [Test, TestCaseSource("TestCases")]
    public void Test(SimpleDelegate action1, SimpleDelegate action2, SimpleDelegate action3)
    {
        action1();
        action2();
        action3();
    }
