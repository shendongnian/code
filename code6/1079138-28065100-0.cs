    public static int Count(this IQueryable q)
    {
        return (int)q.Provider.Execute(
            Expression.Call(typeof(Queryable),
                "Count",
                new[] { q.ElementType },
                new[] { q.Expression }));
    }
