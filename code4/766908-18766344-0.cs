    public static IQueryable<T> Where<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate)
            {
                source = Queryable.Where(source, i => Convert.ToBoolean(i.GetType().GetProperty("IsActive").GetValue(i, null)));
                source = Queryable.Where<T>(source, predicate);
                return source;
            }
