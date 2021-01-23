    public async Task WaitForReaderArrivalAsync()
    {
        while (!ReaderArrived())
        {
            await Task.Delay(1000).ConfigureAwait(false);
        }
    }
