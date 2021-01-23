    public static class IQueryableExtension
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            
            var memberProp = typeof(T).GetProperty(propertyName);
            var method = typeof(IQueryableExtension).GetMethod("OrderByInternal")
                                       .MakeGenericMethod(typeof(T), memberProp.PropertyType);
            return (IOrderedQueryable<T>)method.Invoke(null, new object[] { query, memberProp });
        }
        public static IOrderedQueryable<T> OrderByInternal<T, TProp>(IQueryable<T> query, PropertyInfo memberProperty)
        {
            if (memberProperty.PropertyType != typeof(TProp)) throw new Exception();
            var thisArg = Expression.Parameter(typeof(T));
            var lamba = Expression.Lambda<Func<T, TProp>>(Expression.Property(thisArg, memberProperty), thisArg);
            return query.OrderBy(lamba);
        }
    }
