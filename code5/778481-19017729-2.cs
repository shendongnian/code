    public static bool InvokeOperationMethod(
        MethodInfo method, object obj, Func<object, bool> opAsObject)
    {
        var targetType = method.GetParameters()
                               .Single()
                               .ParameterType
                               .GetGenericArguments()[0];
        object opAsT;
        if (targetType.IsValueType)
        {
            opAsT =
                typeof(Program).GetMethod("BoxParameter",
                BindingFlags.NonPublic | BindingFlags.Static)
                               .MakeGenericMethod(targetType)
                               .Invoke(null, new object[] {opAsObject});
        }
        else
        {
            opAsT = opAsObject;
        }
        return (bool)method.Invoke(obj, new[] { opAsT });
    }
