    public Task<MyCustomStatus> LongRunningOperationAsync()
    {
        return Task.Factory.StartNew(() => 
                                     {
                                          //Long Running method here
                                          return myCustomStatus;
                                     });
    }
