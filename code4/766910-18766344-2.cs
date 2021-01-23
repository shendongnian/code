    public static IQueryable<T> Where<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
            {
                source = source = source.Where("isActive == true"); // From System.linq.Dynamic Library
                source = Queryable.Where<T>(source, predicate);
                return source;
            }
