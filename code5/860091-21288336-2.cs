    public static IQueryable<MyEntity> InBetween(this IQueryable<MyEntity> queryable,
        DateTime start, DateTime end)
    {
        return queryable.Where(InBetween(start, end));
    }
    public static Expression<Func<MyEntity, bool>> InBetween(DateTime start,
        DateTime end)
    {
        return x => x.DateColumn >= start && x.DateColumn < end;
    }
