    var client = new HttpClient();
    List<Exception> exceptions = new List<Exception>();
    var searchPromises = searchTerms
        .Select(GetSearchUrl)
        .Select(client.GetStringAsync)
        .Select(t => t.ContinueWith(r =>
                {
                    if (!r.IsFaulted)
                    {
                        return r.Result;
                    }
                    exceptions.Add(r.Exception);
                    return null;
                }));
    var searchPages = (await Task.WhenAll(searchPromises))
        .Where(r => r != null);
