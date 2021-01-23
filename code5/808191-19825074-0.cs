    public async Task Bar()
    {
        await _lock.WaitAsync();
        await BarInternal_UnderLock();
        _lock.Release();
    }
    public async Task BarInternal()
    {
        await _lock.WaitAsync();
        await BarInternal_UnderLock();
        _lock.Release();
    }
    private async Task BarInternal_UnderLock()
    {
        // DO work
    }
