    if(info.ParameterType.IsGenericType &&
         info.ParameterType.GetGenericTypeDefinition() == typeof(List<>))
    {
        // create list
        IList objList = (IList)Activator.CreateInstance(info.ParameterType);
        // resolve T in List<T>
        Type type = info.ParameterType.GetGenericArguments()[0];
        // avoid problems with List<Nullable<Something>>
        type = Nullable.GetUnderlyingType(type) ?? type;
        
        // now apply any type-specific rules as per your existing code
        ..
        // add to list
        objList.Add(objectDefaultValue);
    }
