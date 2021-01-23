    public Task DoAThingAsync()
    {
        var method = MethodBase.GetCurrentMethod();
        LogMethod(method);
        return doWork();
        
        // Define inner function to actually do the work
        async Task doWork()
        {
             // Do the work here
        }
    }
