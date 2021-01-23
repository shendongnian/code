    #if DEBUG
    
    [Fact]
    public void ThisIsATestThatWillOnlyRunInDebugMode()
    {
        throw new Exception("I am running in debug mode.");
    }
    #endif
