    public void Match<T>(Expression<Func<T>> original, Expression<Func<T>> updated)
    {
        var mex = original.Body as MemberExpression;
        var valueOriginal = original.Compile()();
        var valueUpdated = updated.Compile()();
        if (!object.Equals(valueOriginal, valueUpdated))
        {
            var info = mex.Member as PropertyInfo;
            var target = Expression.Lambda(mex.Expression).Compile().DynamicInvoke();
            info.SetValue(target, valueUpdated);
        }
    }
