    public Type CreateNullable(Type type){
        if (type.IsValueType && (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Nullable<>)))
            return typeof(Nullable<>).MakeGenericType(type);
    
        // Is already nullable
        return type;
    }
