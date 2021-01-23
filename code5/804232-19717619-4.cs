    var cts = new CancellationTokenSource(3000); // Set timeout
    
    var task = Task.Run(() =>
    {
        while (!cts.Token.IsCancellationRequested)
        {
            // Working...
        }
    
    }, cts.Token);
