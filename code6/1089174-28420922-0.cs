    private static int run = 0;
    
    ...
    
    [Test]
    [Retry(Times = 3, RequiredPassCount = 2)]
    public void One_Failure_On_Three_Should_Pass()
    {
        run++;
    
        if (run == 1)
        {
            Assert.Fail();
        }
    
        Assert.Pass();
    }
