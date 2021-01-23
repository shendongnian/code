    public virtual void Delete(T entity)
    {    
        var entry = _context.Entry(entity);
        if (_context.Entry(entity).State == EntityState.Detached)
           _context.Set(typeof(T)).Attach(entity);
        _context.Set(typeof(T)).Remove(entity);
        entry.State = EntityState.Deleted;
    }
