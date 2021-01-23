    var filter = new HttpBaseProtocolFilter();
    filter.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
    filter.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;
    using (var httpClient = new HttpClient(filter))
    {
        httpClient.DefaultRequestHeaders.Add("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
        Uri uri;
        Uri.TryCreate(someUrl + "?ts=" + DateTime.Now.Ticks, UriKind.Absolute, out uri);
                    
        var json = await httpClient.GetStringAsync(uri);
        // Now do something with the json.
    }
