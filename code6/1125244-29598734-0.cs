    MethodBuilder mb = dest.DefineMethod(
       method.Name,
       method.Attributes);
    if (method.IsGenericMethod)
    {
        Type[] genericTypes = method.GetGenericArguments();
        foreach (Type t in genericTypes)
        {
            mb.DefineGenericParameters(t.Name);
        }
    }
    mb.SetReturnType(method.ReturnType);
    mb.SetParameters(param_types);
