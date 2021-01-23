    private SemaphoreSlim _mutex = new SemaphoreSlim(5);
    private HttpClient _client = new HttpClient();
    private async Task<string> DownloadStringAsync(string url)
    {
      await _mutex.TakeAsync();
      try
      {
        return await _client.GetStringAsync(url);
      }
      finally
      {
        _mutex.Release();
      }
    }
    IEnumerable<string> urls = ...;
    var data = await Task.WhenAll(urls.Select(url => DownloadStringAsync(url));
