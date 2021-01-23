    public int Add(int? a, int? b)
    {
        if(!a.HasValue)
            throw new ArgumentNullException("a");
        if(!b.HasValue)
            throw new ArgumentNullException("b");
        return a.Value + b.Value;
    }
