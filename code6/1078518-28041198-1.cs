    private static Expression<Func<T, bool>> Convert<T>(Expression<Func<T, object>> input)
    {
        ParameterExpression t = Expression.Parameter(typeof (T), "t");
        return Expression.Lambda<Func<T, bool>>(
            Expression.Call(typeof(Program).GetMethod("ConvertToBool"), Expression.Invoke(input, t)),
            new[] {t}
        );
    }
    public static bool ConvertToBool(object input)
    {
        return (bool)input;
    }
