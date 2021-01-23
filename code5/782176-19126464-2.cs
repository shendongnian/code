    public static object DefaultValueForParameter(Type type, string methodName, int parameterNumber)
    {
        return type.GetMethod(methodName).GetParameters()[parameterNumber].DefaultValue;
    }
    ExampleMethod(param < 20 ? param : (int)DefaultValueForParameter(this.GetType(), "ExampleMethod", 0));
