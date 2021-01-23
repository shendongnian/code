    private Task DoWork(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            // ... It would be nice if you could await something here.
        }
        return Task.FromResult(true);
    }
