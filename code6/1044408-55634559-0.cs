    var cts = new CancellationTokenSource();
    Task t = DoWork();
    async Task DoWork()
    {
        while (true)
        {
            cts.Token.ThrowIfCancellationRequested();
            try
            {
                "Running...".Dump();
                await Task.Delay(500, cts.Token);
            }
            catch (TaskCanceledException) { }
        }
    }
