    [Test, TestCaseSource("TestData")] 
    public void Test1(string testName, Foo foo)
    {
        // test 1
    }
    
    [Test, TestCaseSource("TestData")] 
    public void Test2(String testName, Foo foo)
    {
        // test 2
    }
    
