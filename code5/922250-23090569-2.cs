    void Main()
    {
        var original = new List<int>(new[] { 1, 2, 3, 4 });
        var filtered = original.Where(i => i > 2);
        original.Add(5);
        filtered.Dump();
        original.Add(6);
        filtered.Dump();
    }
