        var methodsToVerify = typeof(RealRepo)
            .GetMethods()
            .Where(m => !m.IsSpecialName);
        foreach (var method in methodsToVerify)
        {
            var arguments = BuildArguments(method);
            var expression = BuildExpression(repo, method, arguments);
            var action = Expression.Lambda<Action<RealRepo>(expression).Compile();
            repo.AssertWasNotCalled(action);
        }
    
    private static IEnumerable<Expression> BuildArguments(MethodInfo methodInfo)
    {
        return methodInfo
            .GetParameters()
            .Select(p => Expression.Constant(Is.Anything()));
    }
    private static Expression BuildExpression(
        object target,
        MethodInfo methodInfo, 
        IEnumerable<Expression> arguments)
    {
        return Expression.Call(Expression.Constant(target), methodInfo, arguments);
    }
