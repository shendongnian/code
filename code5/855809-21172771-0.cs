    public static Expression<Func<NewParam, TResult>> Foo<NewParam, OldParam, TResult>(
        Expression<Func<OldParam, TResult>> expression)
        where NewParam : OldParam
    {
        var param = Expression.Parameter(typeof(NewParam));
        return Expression.Lambda<Func<NewParam, TResult>>(
            expression.Body.Replace(expression.Parameters[0], param)
            , param);
    }
