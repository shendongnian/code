    public static MethodInfo MethodOf([NotNull] Expression<Action> accessExpression, bool dropTypeArguments = false)
    {
        if (accessExpression == null)
            throw new ArgumentNullException("accessExpression");
        var callExpression = accessExpression.Body as MethodCallExpression;
        if (callExpression == null)
            throw new ArgumentException("Expression body must be a method call.", "accessExpression");
        var method = callExpression.Method;
        if (dropTypeArguments && method.IsGenericMethod)
            return method.GetGenericMethodDefinition();
        return method;
    }
    public static MethodInfo MethodOf<TInstance>([NotNull] Expression<Action<TInstance>> call, bool dropTypeArguments = false)
    {
        if (call == null)
            throw new ArgumentNullException("call");
        var callExpression = call.Body as MethodCallExpression;
        if (callExpression == null)
            throw new ArgumentException("Expression body must be a method call.", "call");
        var method = callExpression.Method;
        if (dropTypeArguments && method.IsGenericMethod)
            return method.GetGenericMethodDefinition();
        return method;
    }
