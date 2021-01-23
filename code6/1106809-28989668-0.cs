    var client = new HttpClient();
    var searchPromises = searchTerms
      .Select(GetSearchUrl)
      .Select(url => DownloadAsync(client, url));
    var searchPages = await Task.WhenAll(searchPromises);
    var successfulSearchPages = searchPages.Where(x => x != null);
    ...
    private static async Task<string> DownloadAsync(HttpClient client, string url)
    {
      try
      {
        return await client.GetStringAsync(url);
      }
      catch (HttpRequestException ex)
      {
        // TODO: Perform appropriate error handling
        return null;
      }
    }
