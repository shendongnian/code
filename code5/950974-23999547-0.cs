    public void Update<T>(T entity, Func<T, dynamic> callback)
    {
        foreach (var p in callback(entity).GetType().GetProperties())
            _context.Entry<T>(entity).Property(p.Name).IsModified = true;
    }
