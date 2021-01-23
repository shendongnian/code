    public void Update<T>(object dto, params object[] keyValues)
        where T : class
    {
        var current = DataContext.Set<T>().Find(keyValues);
        DataContext.Entry(current).CurrentValues.SetValues(dto);
    }
