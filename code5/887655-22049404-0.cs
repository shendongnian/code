    public async Task TimedLoop(Action action, 
        CancellationToken token, TimeSpan delay)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            action();
            await Task.Delay(delay);
        }
    }
