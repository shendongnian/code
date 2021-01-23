    public T GetRecord(T obj)
    {
        return this.Where(t => t.Equals(obj))
                   .Select(t => t).FirstOrDefault();
    }
