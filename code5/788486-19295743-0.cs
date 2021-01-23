    public static IQueryable<T> Active(this IQueryable<T> entityCollection)
        where T : EntityBase
    {
        return entityCollection.Where(e => e.Enabled && !e.Deleted);
    }
