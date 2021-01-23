        public static class IQueryableEx
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
        }
