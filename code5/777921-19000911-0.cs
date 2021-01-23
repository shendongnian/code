    public static void AssertNothingWasCalled<I, T>(this T mock)
    {
        var methodsToVerify = typeof(I)
            .GetMethods()
            .Where(m => !m.IsSpecialName);
        foreach (var method in methodsToVerify)
        {
            var arguments = BuildArguments(method);
            var expression = BuildExpression(mock, method, arguments);
            var action = new Action<RealRepo>(expression);
            mock.AssertWasNotCalled(action);
        }
    }
    private static IEnumerable<Expression> BuildArguments(MethodInfo methodInfo)
    {
        return methodInfo.GetParameters().Select(p => Is.Anything());
    }
    private static Expresssion BuildExpression(
        object target,
        MethodInfo methodInfo, 
        IEnumerable<Expression> arguments)
    {
        return Expression.Call(target, methodInfo, arguments);
    }
