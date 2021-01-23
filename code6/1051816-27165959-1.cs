    private SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
    private HttpClient _httpClient = new HttpClient();
    public async Task SendRequestAsync(HttpWebRequest request)
    {
          await _semaphoreSlim.WaitAsync();
          try
          {
             return await _httpClient.SendAsync(request);
          }
          finally
          {
             _semaphoreSlim.Release();
          }
    }
