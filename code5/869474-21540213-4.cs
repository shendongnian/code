    private static Dictionary<string, Action<object>> _actions;
    static Test()
    {
        _actions = typeof(Test).GetMethods(BindingFlags.Static | BindingFlags.Public)
                               .Where(m => m.Name.StartsWith("SubProcess"))
                               .ToDictionary(m => m.Name, m => GetLambda(m));
    }
    private static Action<object> GetLambda(MethodInfo method)
    {
        ParameterExpression param = Expression.Parameter(typeof(object));
        return Expression.Lambda<Action<object>>(Expression.Call(method, param), param).Compile();
    }
