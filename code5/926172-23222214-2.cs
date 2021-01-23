    void Main()
    {
        List<int> a = new List<int> { 1, 2, 5, 10 };
        List<int> b = new List<int> { 6, 20, 3 };
    
        var result = Enumerable.Zip(a, b, (aElement, bElement) => new[] { aElement, bElement })
            .SelectMany(ab => ab)
            .Concat(a.Skip(Math.Min(a.Count, b.Count)))
            .Concat(b.Skip(Math.Min(a.Count, b.Count)));
    
        result.Dump();
    }
