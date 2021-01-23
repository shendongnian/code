    SomeMethodAsync(CancellationToken token)
    {
        Task t = Task.Factory.StartNew(() => 
            {
                msTimeout = 5000;
                Pump(token);
            }, token,
               TaskCreationOptions.None,
               TaskScheduler.Default);
    }
    
