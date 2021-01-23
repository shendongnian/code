    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.FailCount;
        if (status > 0)
            Console.WriteLine("Test Failed: {0}\r\nMessage:\r\n{1}", 
                               TestContext.CurrentContext.Test.FullName, 
                               TestContext.CurrentContext.Result.Message);          
    } 
