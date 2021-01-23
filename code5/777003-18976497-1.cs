    public static T GetSingle<T>(IQueryable<T> collection, 
        Expression<Func<T, bool>> predicate, Guid id)
        where T : IEntity
    {
        T entity;
        predicate = EntityCastRemoverVisitor.Convert(predicate);
        try
        {
            entity = collection.SingleOrDefault(predicate);
        }
