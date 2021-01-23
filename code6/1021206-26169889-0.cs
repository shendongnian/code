    System.Action act = () =>
    {
        var typeName = "";
        var methodName = "";
        var type = System.Type.GetType(typeName);
        var method = type.GetMethod(methodName);
        object[] constructorArgs = null;
        var obj = type.InvokeMember(null,  System.Reflection.BindingFlags.CreateInstance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, null, null, constructorArgs);
        object [] methodArgs = null;
        method.Invoke(obj, methodArgs);
    };
    System.Linq.Expressions.Expression<System.Action> exp = () => act();
    exp.Compile()();
