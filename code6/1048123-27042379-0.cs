    static async Task<string> DownloadAllAsync(IEnumerable<string> urls)
    {
      var httpClient = new HttpClient();
      var downloads = urls.Select(url => TryDownloadAsync(httpClient, url));
      Task<string>[] downloadTasks = downloads.ToArray();
      string[] htmlPages = await Task.WhenAll(downloadTasks);
      return string.Concat(htmlPages);
    }
    static async Task<string> TryDownloadAsync(HttpClient client, string url)
    {
      try
      {
        return await client.GetStringAsync(url);
      }
      catch (Exception ex)
      {
        Log(ex);
        return string.Empty; // or whatever you prefer
      }
    }
