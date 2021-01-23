    public void Update<T>(T entity, object modify)
    {
        foreach (PropertyInfo p in modify.GetType().GetProperties())
            _context.Entry<T>(entity).Property(p.Name).IsModified = true;
    }
