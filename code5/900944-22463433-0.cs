    void Main()
    {
        var ints = Enumerable.Range(1,10).ToArray();
        AddInt(ints, 11);
        ints.Dump();
    }
    
    void AddInt(IEnumerable<int> list, int i)
    {
        list = list.Concat(new[] {i});
        list.Dump();
    }
