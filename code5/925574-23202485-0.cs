    public IQueryable<TEntity> PaginateAndOrderByDesc<TEntity, TKey>(
        int pageIndex, 
        int pageSize,
        Expression<Func<TEntity, TKey>> sortSelector)
    where TEntity : class, IContextEntity
    {
        int numberOfRecordsToSkip = (pageIndex - 1) * pageSize;
        return context.Set<TEntity>()
            .OrderByDescending(sortSelector)
            .Skip(numberOfRecordsToSkip)
            .Take(pageSize);
    }
