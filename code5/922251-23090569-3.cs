    void Main()
    {
        var original = new List<int>(new[] { 1, 2, 3, 4 });
        var filtered = original.Where(i => i > 2).ToList();
        original.Add(5);
    
        original.Dump();
        filtered.Dump();
    }
