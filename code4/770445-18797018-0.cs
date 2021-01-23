    public IQueryable<T> Query(Expression<Func<T, bool>> predicate) where T : class
    {
        Entities dbContext = DAODbContext.Instance.EntitiesFactory();
    
        var dbSet = dbContext.Set<T>();
    
    
    
        return dbSet.Where(predicate);
    }
