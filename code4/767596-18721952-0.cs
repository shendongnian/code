    public static Task<string> DownloadStringAsync(string address)
    {
      // First try to retrieve the content from cache.
      string content;
      if (cachedDownloads.TryGetValue(address, out content))
      {
        return Task.FromResult(content);
      }
      // If the result was not in the cache, download the  
      // string and add it to the cache.
      return DownloadAndCacheStringAsync(address);
    }
    private static async Task<string> DownloadAndCacheStringAsync(string address)
    {
      var content = await new WebClient().DownloadStringTaskAsync(address);
      cachedDownloads.TryAdd(address, content);
      return content;
    }
