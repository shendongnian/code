    private string GetRandomSearchEngine()
    {
        var searchEngine = _engines
        // randomize the collection
            .OrderBy(x => Guid.NewGuid())
        // skip items with invalid counter
            .SkipWhile(t => t.Counter >= 100)
            .First();
        // update the counter
        searchEngine.Counter++;
        return searchEngine.Url;
    }
