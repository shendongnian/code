    string typeName = "System.Console"; // remember the namespace
    string methodName = "Clear";
    Type type = Type.GetType(typeName);
    if (type != null)
    {
        MethodInfo method = type.GetMethod(methodName);
        if (method != null) 
        {
            method.Invoke(null, null);
        }
    }
