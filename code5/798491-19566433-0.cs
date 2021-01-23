    public static IEnumerable<IEnumerable<string>> SubSetsOf(List<string> source)
    {
        if (!source.Any())
            return Enumerable.Repeat(Enumerable.Empty<string>(), 1);
    
        var element = source.Take(1);
    
        var haveNots = SubSetsOf(source.Skip(1).ToList()).ToList();
        var haves = haveNots.Select(element.Concat);
    
        return haves.Concat(haveNots);
    }
    private static void Main(string[] args)
    {
            string[] words = { "test", "rock", "fun" };
            var subSetsOf = SubSetsOf(words.ToList());
    }
