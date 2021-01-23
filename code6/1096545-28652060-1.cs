    public static T EnableLazyLoading<T, TEntity, TKey>(
        this T @this,
        bool enabled)
                           where T       : IBaseService<TEntity, TKey>
                           where TEntity : Entity<TKey>
                           where TKey    : struct
    {
        @this.UnitOfWork.EnableLazyLoading(enabled);
        @this.UnitOfWork.EnableProxyCreation(enabled);
        return @this;
    }
