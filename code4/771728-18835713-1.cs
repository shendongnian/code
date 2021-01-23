    public static IQueryable<T> WhereFunctionContains<T>(this IQueryable<T> query, Expression<Func<T,int>> converter)
    {    
        var intsToFind = FillObjectsToFind();
        return query.Where(t => intsToFind.Contains(converter(t)));
    }
