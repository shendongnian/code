    public static T GetById<T>(this IQueryable<T> collection, 
        Expression<Func<T, bool>> predicate, Guid id)
        where T : IEntity
    {
        T entity;
        // Add this line!
        predicate = EntityCastRemoverVisitor.Convert(predicate);
        try
        {
            entity = collection.SingleOrDefault(predicate);
        }
        ...
    }
