    void Main()
    {
        var l = new List<string>(10);
        l.Dump(); // empty list
    
        l.Add("Item");
        l.Dump(); // one item
    
        l[0] = "Other item";
        l.Dump(); // still one item
    
        l.Capacity.Dump(); // should be 10
        l.AddRange(Enumerable.Range(1, 20).Select(idx => idx.ToString()));
        l.Capacity.Dump(); // should be 21 or more
    }
