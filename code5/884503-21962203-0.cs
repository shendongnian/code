    public static IQueryable<T> LoadNavigationProperty(this IQueryable<T> query, Expression<Func<T, object>>[] navigationProperties)
    {
        if ((query != null) && (navigationProperties != null))
        {
            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include<T, object>(navigationProperty);
            }
        }
    
        return query;
    }
