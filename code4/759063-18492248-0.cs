    public static IQueryable<T> DynamicContains<T, TProperty>(
        this IQueryable<T> query, 
        string property, 
        IEnumerable<TProperty> items)
    {
        var pe = Expression.Parameter(typeof(T));
        var me = Expression.Property(pe, typeof(T).GetProperty("Id"));
        var ce = Expression.Constant(items);
        var call = Expression.Call(typeof(Enumerable), "Contains", new[] { me.Type }, ce, me);
        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(call, pe);
        return query.Where(lambda);
    }
    db.DynamicContains("Id", ids);
