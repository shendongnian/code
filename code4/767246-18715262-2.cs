    SomeMethodAsync(CancellationToken token)
    {
        Task t = Task.Factory.StartNew(() => 
            {
                // Do stuff.
                token.ThrowIfCancellationRequested();
            }, token,
               TaskCreationOptions.None,
               TaskScheduler.Default);
    }
    
