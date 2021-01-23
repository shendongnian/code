        var methodsToVerify = typeof(RealRepo)
            .GetMethods()
            .Where(m => !m.IsSpecialName);
        foreach (var method in methodsToVerify)
        {
            var arguments = BuildArguments(method);
            var expression = BuildExpression(repo, method, arguments);
            var action = new Action<RealRepo>(expression);
            repo.AssertWasNotCalled(action);
        }
    
    private static IEnumerable<Expression> BuildArguments(MethodInfo methodInfo)
    {
        return methodInfo.GetParameters().Select(p => Is.Anything());
    }
    private static Expression BuildExpression(
        object target,
        MethodInfo methodInfo, 
        IEnumerable<Expression> arguments)
    {
        return Expression.Call(target, methodInfo, arguments);
    }
