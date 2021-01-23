    public static ParallelQuery<T> OrderBy<T>(this ParallelQuery<T> source, string sortProperty, ListSortDirection sortOrder)
    {
        var type = typeof(T);
        var property = type.GetProperty(sortProperty);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByFunc = Expression.Lambda(propertyAccess, parameter).Compile();
        if (sortOrder == ListSortDirection.Ascending)
        {
            return ParallelEnumerable.OrderBy(source, (dynamic)orderByFunc);
        }
        else
        {
            return ParallelEnumerable.OrderByDescending(source, (dynamic)orderByFunc);
        }
    }
