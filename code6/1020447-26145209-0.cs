    [TestCaseSource("SmackTestCases")]
    public void Smack(int a, int b) { ... }
    static object[] SmackTestCases =
    {
        new object[] { 1, 2 },
        new object[] { 3, 4 },
        new object[] { 5, 6 } 
    };
