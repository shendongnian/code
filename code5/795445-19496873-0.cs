    private readonly AsyncReaderWriterLock _lock = new AsyncReaderWriterLock();
    private async Task MasterAsync()
    {
        using (await _lock.WriterLockAsync())
        {
            await Task.Delay(2000);
        }
    }
    private async Task HumbleSlave1Async()
    {
        using (await _lock.ReaderLockAsync())
        {
            await Task.Delay(5000);
        }
    }
    private async Task HumbleSlave2Async()
    {
        using (await _lock.ReaderLockAsync())
        {
            await Task.Delay(5000);
        }
    }
