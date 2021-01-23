    public object ReturnValue(string operationName, object returnValue)
    {
        Type t = returnValue.GetType();
        return Activator.CreateInstance(t);
    }
