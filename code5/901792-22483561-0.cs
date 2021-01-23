    private IEnumerable<Tuple<string,int>> engines = new[]
    {
        Tuple.Create("www.google.com", 0),
        Tuple.Create("www.bing.com", 0),
        Tuple.Create("www.yahoo.com", 0)
    };
    private string GetRandomSearchEngine()
    {
        var tuple = _engines
        // randomize the collection
            .OrderBy(x => Guid.NewGuid())
            .SkipWhile(t => t.Item2 >= 100)
            .First();
        // update the counter
        tuple.Item2++;
        return tuple.Item1;
    }
