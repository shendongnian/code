    var param = Expression.Parameter(typeToLookUp, "x");
    var property = Expression.Property(param, propParam);  
    var doubleValue = Expression.Convert(property, typeof(double));
    var bodyLeft = Expression.Call(stringConvertMethod, doubleValue);
    
