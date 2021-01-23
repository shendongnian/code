    [Test, TestCaseSource("TestData_Test1")] 
    public void Test1(Foo foo)
    {
        // test 1
    }
    
    [Test, TestCaseSource("TestData_Test2")] 
    public void Test2(Foo foo)
    {
        // test 2
    }
    
    
    private static IEnumerable TestData_Test1() 
    {
       return TestData_Base("Test1"); 
    } 
    
    private static IEnumerable TestData_Test2() 
    {
       return TestData_Base("Test2"); 
    } 
    
    private static IEnumerable TestData_Base(string testName) 
    {
       TestCaseData data; 
    
       data = new TestCaseData(new Foo("aaa"));
       data.SetName(string.Format("{0}(Foo=aaa)", testName)); 
       yield return data; 
    
       data = new TestCaseData(new Foo("bbb"));
       data.SetName(string.Format("{0}(Foo=bbb)", testName)); 
       yield return data; 
    }
