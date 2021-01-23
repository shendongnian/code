    public void Update<T>(T entity, Func<T, object> modify)
    {
        foreach (PropertyInfo p in modify(entity).GetType().GetProperties())
            _context.Entry<T>(entity).Property(p.Name).IsModified = true;
    }
