    
    void LongMethod(CancellationToken token)
    {
        for (int i=0; i<51; ++i)
        {
            token.ThrowIfCancellationRequested();
            Thread.Sleep(1000); // some sub operation
        }
    }
    void Run()
    {
        var source = new CancellationTokenSource(50000); // 50 sec delay
        var task = new Task(() => LongMethod(source.Token), source.Token);
        task.Wait();
    }
