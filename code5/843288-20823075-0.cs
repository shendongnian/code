    private static Func<Object, Object> GenerateAccessor(MethodInfo methodInfo)
    {
        Type typeObject = typeof(Object);
        ParameterExpression @object = Expression.Parameter(typeObject, "Objet");
        UnaryExpression unaryExpression = Expression.Convert(@object, methodInfo.DeclaringType);
        MethodCallExpression methodCallExpression = Expression.Call(unaryExpression, methodInfo);
        UnaryExpression unaryExpressionBis = Expression.Convert(methodCallExpression, typeObject);
        Expression<Func<Object, Object>> epxressionFuncObjectObject = Expression.Lambda<Func<Object, Object>>(unaryExpressionBis, @object);
        return epxressionFuncObjectObject.Compile();
    }
