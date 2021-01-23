    invocation.Proceed(); 
    object response;
    Type type = invocation.ReturnValue?.GetType();
    if (type != null && typeof(Task).IsAssignableFrom(type))
    {
        var resultProperty = type.GetProperty("Result");
        response = resultProperty.GetValue(invocation.ReturnValue);
    }
