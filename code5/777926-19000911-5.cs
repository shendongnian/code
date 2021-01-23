    public static AssertNothingWasCalled<T>(this T mock)
    {
        var methodsToVerify = typeof(T)
            .GetMethods()
            .Where(m => !m.IsSpecialName);
        foreach (var method in methodsToVerify)
        {
            var arguments = BuildArguments(method);
            var action = new Action<T>(x => method.Invoke(x, aguments));
            Rhino.Mocks.RhinoMocksExtensions.AssertWasNotCalled(
                mock,
                action,
                y => y.IgnoreArguments());
        }
    
    private static object[] BuildArguments(MethodInfo methodInfo)
    {
        return methodInfo
            .GetParameters()
            .Select(p => Arg<object>.Is.Anything)
            .ToArray();
    }
