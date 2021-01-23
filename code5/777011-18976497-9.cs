    // NOTE: This is an extension method on DbSet<T> instead of IQueryable<T>
    public static T GetById<T>(this DbSet<T> collection, Guid id) 
        where T : class, IEntity
    {
        T entity;
        // Allow reporting more descriptive error messages.
        try
        {
            entity = collection.Find(id);
        }
        ...
    }
