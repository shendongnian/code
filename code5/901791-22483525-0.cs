    static List<string> engines = new List<string> (Enumerable.Repeat("www.google.com", 100)
            .Concat(Enumerable.Repeat("www.bing.com", 100))
            .Concat(Enumerable.Repeat("www.yahoo.com", 100)));
    static Random rnd = new Random();
    private static string getSearchEngine()
    {
        int i = rnd.Next(0, engines.Count);
        var temp = engines[i];
        engines.RemoveAt(i);
        return temp;
    }
