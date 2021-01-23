    public static TService EnableLazyLoading<TService, TEntity, TKey>(this TService service)
        where TService : IBaseService<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct
    {
        // do stuff
        return service;
    }
