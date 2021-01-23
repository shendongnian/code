    var entry = db.Entry(entity);
    if (entry.State == EntityState.Detached)
    {
        db.Set<TEntity>().Attach(entity);
    }
    entry.Property("propertyName").IsModified = true
