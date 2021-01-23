    public Task Example()
    {
        Foo();
        var syncContext = SyncronizationContext.Current;
        return BarAsync().ContinueWith((continuation) =>
                        {
                            syncContext.Post(() => 
                            {
                                string barResult = continuation.Result();
                                Baz(barResult)
                            }
                        });
    }
