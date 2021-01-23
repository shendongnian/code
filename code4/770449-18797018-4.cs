    public IQueryable<SYSLOG> Query(Expression<Func<SYSLOG, bool>> predicate)
    {
        Entities dbContext = DAODbContext.Instance.EntitiesFactory();
    
        var dbSet = dbContext.SYSLOG;
    
        return dbSet.Where(predicate);
    }
