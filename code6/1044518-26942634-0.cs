    public static IQueryable<T> Undeleted(this IQueryable<T> queryable)
        where T : ISoftDeletable
    {
        return queryable.Where(x => !x.IsDeleted);
    }
