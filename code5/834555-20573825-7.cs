    public Task Example()
    {
        Foo();
        var syncContext = SyncronizationContext.Current;
        return BarAsync().ContinueWith((continuation) =>
                        {
                            Action postback = () => 
                            {
                                string barResult = continuation.Result();
                                Baz(barResult)
                            }
                            if(syncContext != null)
                                syncContext.Post(postback);
                            else
                                Task.Run(postback);
                        });
    }
