    public static dynamic EnableLazyLoading<TEntity, TPrimaryKey>(
        this IBaseEntityService<TEntity, TPrimaryKey> baseService,
        bool enabled)  
        where TEntity :Entity<TPrimaryKey> where TPrimaryKey : struct
    {
        baseService.UnitOfWork.EnableLazyLoading(enabled);
        baseService.UnitOfWork.EnableProxyCreation(enabled);
        return baseService;
    }
