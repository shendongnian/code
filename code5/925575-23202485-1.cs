    public static IQueryable<TEntity> GetPage<TEntity>(
        this IOrderedQueryable<TEntity> query,
        int pageIndex,
        int pageSize)
    {
        int numberOfRecordsToSkip = (pageIndex - 1) * pageSize;
        return query.Skip(numberOfRecordsToSkip)
            .Take(pageSize);
    }
