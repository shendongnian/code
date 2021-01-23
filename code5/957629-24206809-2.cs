    public static void Match<T>(Expression<Func<T>> original, 
        Expression<Func<T>> updated)
    {
        var mex = original.Body as MemberExpression;
        var valueOriginal = original.Compile()();
        var valueUpdated = updated.Compile()();
        if (!object.Equals(valueOriginal, valueUpdated))
        {
            var body = Expression.Assign(
                Expression.MakeMemberAccess(mex.Expression, mex.Member),
                updated.Body);
            Expression.Lambda<Action>(body).Compile().Invoke();
        }
    }
