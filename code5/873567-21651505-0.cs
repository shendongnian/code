    Windows.Web.Http.Filters.HttpBaseProtocolFilter filter =
        new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
    filter.CacheControl.ReadBehavior =
        Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
    HttpClient client = new HttpClient(filter);
    Uri uri = new Uri("http://example.com");
    HttpResponseMessage response = await client.GetAsync(uri);
    response.EnsureSuccessStatusCode();
    string str = await response.Content.ReadAsStringAsync();
