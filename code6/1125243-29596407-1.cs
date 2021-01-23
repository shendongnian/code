    #if !DEBUG
    
    [Fact]
    public void ThisIsATestThatWillNotRunInDebugMode()
    {
        throw new Exception("I am running in in something other than debug mode.");
    }
    #endif
