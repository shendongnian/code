    public static dynamic EnableLazyLoading<TEntity, TPrimaryKey>(
        this IBaseEntityService<TEntity, TPrimaryKey> @this,
        bool enabled)  
                            where TEntity     : Entity<TPrimaryKey> 
                            where TPrimaryKey : struct
    {
        @this.UnitOfWork.EnableLazyLoading(enabled);
        @this.UnitOfWork.EnableProxyCreation(enabled);
        return @this;
    }
