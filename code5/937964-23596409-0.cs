    private bool UniqueCheck(params string[] items)
    {
        return UniqueCheck((IEnumerable<string>)items);
    }
    private bool UniqueCheck(IEnumerable<string> items)
    {
        var hs = new HashSet<string>();
    
        foreach (var item in items)
            if (!hs.Add(item))
                return false;
    
        return true;
    }
