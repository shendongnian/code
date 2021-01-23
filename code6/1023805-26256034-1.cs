    public static Func<TIn, TOut> CreateGetter<TIn, TOut>(string propertyName)
    {
       var input = Expression.Parameter(typeof(TIn));
       var expression = Expression.Property(input, typeof(TIn).GetProperty(propertyName));
       return Expression.Lambda<Func<TIn, TOut>>(expression, input).Compile();
    }
