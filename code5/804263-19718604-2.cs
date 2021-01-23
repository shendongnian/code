    var cts = new CancellationTokenSource(3000); // Set timeout
    
    Task.Run(() =>
    {
        while (!cts.Token.IsCancellationRequested)
        {
            // Doing Work...
        }
    
    }, cts.Token);
