    public static class QueryableEx
    {
        public static IQueryable<T> IncludeIf<T, TProperty>(this IQueryable<T> source, bool condition, Expression<Func<T, TProperty>> path) where T : class
        {
            if (condition)
            {
                return source.Include(path);
            }
            else
            {
                return source;
            }
        }
        public static DbQuery<TResult> IncludeIf<TResult>(this DbQuery<TResult> query, bool condition, string path)
        {
            if (condition)
            {
                return query.Include(path);
            }
            else
            {
                return query;
            }            
        }
    }
