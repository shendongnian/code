    public int GetMaxPK<T>(this IQueryable<T> query, string pkPropertyName)
    {
    	// TODO: add argument checks
    	var parameter = Expression.Parameter(typeof(T));
    	var body = Expression.Property(parameter, pkPropertyName);
    	var lambda = Expression.Lambda<Func<T,int>>(body, parameter);
    	var result = query.Max (lambda);
    	return result;
    }
