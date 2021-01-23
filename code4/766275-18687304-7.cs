    var obj = new General<int>();
    var type = obj.GetType();
    var isGeneral = 
    (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(General<>)) ||
    type.GetBaseTypes().Any(x => x.IsGenericType && 
                                 x.GetGenericTypeDefinition() == typeof(General<>));
