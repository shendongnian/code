    public static string GetPropertyName<T, TReturn>(System.Linq.Expressions.Expression<Func<T, TReturn>> expression)
    {
        System.Linq.Expressions.MemberExpression body = (System.Linq.Expressions.MemberExpression)expression.Body;
        return body.Member.Name;
    }
