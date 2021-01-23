    public void Remove<T>(params T[] items) where T : class, ITenantData
    {
        var set = realContext.Set<T>();
        foreach(var item in items)
            set.Remove(item);
    }
    
    public void Add<T>(params T[] items) where T : class, ITenantData
    {
        var set = realContext.Set<T>();
        foreach (var item in items)
            set.Add(item);
    }
