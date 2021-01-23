    [TestCase("set", Result = "set")]
    public string MyTest(string optional)
    {
        return optional;          
    }
    
    [TestCase(Result = "optional")]
    public string MyTest()
    {
        return MyTest("optional");          
    }
