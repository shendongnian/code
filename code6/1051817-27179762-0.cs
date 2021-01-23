    private readonly HttpClient _client = new HttpClient();
    private readonly AsyncLock _mutex = new AsyncLock();
    public async Task<string> GetStringAsync(string url)
    {
        using (await _mutex.LockAsync())
        {
            return await _client.GetStringAsync(url);
        }
    }
