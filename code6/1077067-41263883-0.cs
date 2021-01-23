    public static class ExtensionMethods
    {
      public static IQueryable<T> SetQueryName<T>(this IQueryable<T> source,
        [CallerMemberName] String name = null,
        [CallerFilePath] String sourceFilePath = "",
        [CallerLineNumber] Int32 sourceLineNumber = 0)
      {
        var expr = Expression.NotEqual(Expression.Constant("Query name: " + name), Expression.Constant(null));
        var param = Expression.Parameter(typeof(T), "param");
        var criteria1 = Expression.Lambda<Func<T, Boolean>>(expr, param);
    
        expr = Expression.NotEqual(Expression.Constant($"Source: {sourceFilePath} ({sourceLineNumber})"), Expression.Constant(null));
        var criteria2 = Expression.Lambda<Func<T, Boolean>>(expr, param);
    
        return source.Where(criteria1).Where(criteria2);
      }
    }
