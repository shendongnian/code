    protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>()
        where T : class
    {
        return dbContext => new EFRepository<T>(dbContext);
    }
