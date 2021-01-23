    private bool TryGetRandomSearchEngine(out string url)
    {
        var searchEngine = _engines
        // randomize the collection
            .OrderBy(x => _random.Next())
        // skip items with invalid counter
            .SkipWhile(t => t.Counter >= 100)
            .FirstOrDefault();
        if(searchEngine != null)
        {        
            // update the counter
            searchEngine.Counter++;
            url = searchEngine.Url;
            return true;
        }
        url = String.Empty;
        return false;
    } 
