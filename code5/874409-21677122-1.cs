    public async Task WaitForReaderArrival()
    {
        while (!ReaderArrived())
        {
            await Task.Delay(1000).ConfigureAwait(false);
        }
    }
