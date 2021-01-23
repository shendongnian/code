    public static object GetValueGetter<T>(object item, string propertyName, IDictionary<string,Func<T,object>> cache) {
        Func<T, object> propertyResolver;
        if (!cache.TryGetValue(propertyName, out propertyResolver)) {
            var arg = Expression.Parameter(item.GetType(), "x");
            Expression expr = Expression.Property(arg, propertyName);
            var unaryExpression = Expression.Convert(expr, typeof (object));
            propertyResolver = Expression.Lambda<Func<T, object>>(unaryExpression, arg).Compile();
            cache.Add(propertyName, propertyResolver);
        }
        return propertyResolver((T)item);
    }
