    static void Parse(object obj, string property)
    {
        Type type = obj.GetType();
        var method = type.GetProperty(property).GetGetMethod();
        // hard-code that we know the token is at offset 2
        var blob = method.GetMethodBody().GetILAsByteArray();
        int token = BitConverter.ToInt32(blob, 2);
        Type[] typeArgs = null, methodArgs = null;
        if (type.IsGenericType || type.IsGenericTypeDefinition)
            typeArgs = type.GetGenericArguments();
        if (method.IsGenericMethod || method.IsGenericMethodDefinition)
            methodArgs = method.GetGenericArguments();
        var field = type.Module.ResolveField(token, typeArgs, methodArgs);
        Console.WriteLine(field.Name);
        Console.WriteLine(field.MetadataToken);
    }
