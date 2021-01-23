    public async Task RunWorkLoop(CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            await Task.Run(() => new Worker().StartWork()); //runs in ThreadPool
            await Task.Delay(someTimeInterval);
        }
    }
