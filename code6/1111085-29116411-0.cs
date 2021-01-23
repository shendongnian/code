    public async Task Start(CancellationToken token)
    {
        var tasks = new ConcurrentBag<Task>();
        while (!token.IsCancellationRequested)
        {
            // ...
            args.Completed += (s, e) => tasks.Add(AcceptInbound((Socket)s, e));
            // ...
        }
        
        await Task.WhenAll(tasks);
    }
