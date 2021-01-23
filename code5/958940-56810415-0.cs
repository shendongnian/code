    public TestContext TestContext { get; set; } // regular test context
    private static TestContext ClassTestContext { get; set; } // global class test context
    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        ClassTestContext = context;
        context.Properties["myobj"] = <Some Class Level Object>;
    }
    [ClassCleanup]
    public static void ClassCleanup()
    {
        object myobj = (object)ClassTestContext.Properties["myobj"];
    }
    [TestMethod]
    public void Test()
    {
        string testname = (string)TestContext.Properties["TestName"] // object from regular context
        object myobj = (object)ClassTestContext.Properties["myobj"]; // object from global class context
    }
