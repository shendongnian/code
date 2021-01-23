    public static Func<T, object> GetAccessor<T>(string path)
    {
        ParameterExpression paramObj = Expression.Parameter(typeof(T), "obj");
        Expression body = paramObj;
        foreach (string property in path.Split('.'))
        {
            body = Expression.PropertyOrField(body, property);
        }
        return Expression.Lambda<Func<T, object>>(body, new ParameterExpression[] { paramObj }).Compile();
    }
    public static Action<T, object> GetMutator<T>(string path)
    {
        ParameterExpression paramObj = Expression.Parameter(typeof(T), "obj");
        ParameterExpression paramValue = Expression.Parameter(typeof(object), "value");
        Expression body = paramObj;
        foreach(string property in path.Split('.'))
        {
            body = Expression.PropertyOrField(body, property);
        }
        body = Expression.Assign(body, Expression.TypeAs(paramValue, body.Type));
        return Expression.Lambda<Action<T, object>>(body, new ParameterExpression[] { paramObj, paramValue }).Compile();
    }
