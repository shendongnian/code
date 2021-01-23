    private static int sum = 0;
    static void Main(string[] args)
    {
        var dictionary = new Dictionary<string, int>()
        {
            {"1",5},         
            {"2",3},
            {"3",2},
            {"4",1},
            {"5",1},
        };
    
        var total = dictionary.Sum(e => e.Value);
        var cutoff = total * 0.5;
        
        var filtered = dictionary.OrderByDescending(e => e.Value)
            .TakeWhile(e => Add(e.Value).Item1 < cutoff)
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
    
    private static Tuple<int, int> Add(int x)
    {
        return Tuple.Create(sum, sum += x);
    }
