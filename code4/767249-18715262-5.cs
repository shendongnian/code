    SomeMethodAsync(CancellationToken token)
    {
        Task t = Task.Factory.StartNew(() => 
            {
                // Mock long process.
                Thread.Sleep(5000); // Block thread for 5s and simulate expensive work.
                token.ThrowIfCancellationRequested();
            }, token,
               TaskCreationOptions.None,
               TaskScheduler.Default);
    }
    
