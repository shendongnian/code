    private static Action<T> CreateAction<T>(T t, MethodInfo miCommand)
    {
        ParameterExpression bParam = Expression.Parameter(typeof(T));
        Expression castToType = Expression.Convert(bParam, t.GetType(), null);
        return (Action<T>)Expression.Lambda(
                Expression.Call(
                    Expression.Constant(
                        t, miCommand.GetParameters()[0].ParameterType),
                    miCommand, castToType),
                bParam).Compile();
    }
