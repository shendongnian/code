    void RegisterBeforeCancel(CancellationToken token)
    {
        token.Register(() => Console.WriteLine("Before cancel"));
    }
    
    void RegisterAfterCancel(CancellationToken token)
    {
        token.Register(() => Console.WriteLine("After cancel"));
    }
    var cts = new CancellationTokenSource();
    
    RegisterBeforeCancel(cts.Token);
    
    cts.Cancel();
    
    RegisterAfterCancel(cts.Token);
