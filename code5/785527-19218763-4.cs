    static MemberInfo ResolveMember(this MethodInfo method, int metadataToken)
    {
        Type type = method.DeclaringType;
        Type[] typeArgs = null, methodArgs = null;
                
        if (type.IsGenericType || type.IsGenericTypeDefinition)
            typeArgs = type.GetGenericArguments();
        if (method.IsGenericMethod || method.IsGenericMethodDefinition)
            methodArgs = method.GetGenericArguments();
                
        return type.Module.ResolveMember(metadataToken, typeArgs, methodArgs);
    }
