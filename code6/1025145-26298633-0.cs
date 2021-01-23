    private readonly SemaphoreSlim _mutex = new SemaphoreSlim(10);
    ...
    var downloads = images.Select(file => DownloadAsync(file));
    await Task.WhenAll(downloads);
    ...
    private async Task DownloadAsync(string file)
    {
      await _mutex.WaitAsync();
      try
      {
        using (WebClient client = new WebClient())
        {
          await client.DownloadFileTaskAsync(file, path + Path.GetFileName(file));                    
        }
      }
      finally
      {
        _mutex.Release();
      }
    }
