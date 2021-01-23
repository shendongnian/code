    {
        var targetType = Type.GetType(namespaceTargetClassName + "." + targetClassName);
        var p = Expression.Parameter(typeof(object), "Target");
        
        // I'm using the as operator here, if you prefer a "strong" 
        // cast (the cast operator that throws if the object is of
        // invalid type), use Expression.Convert with the same syntax 
        var pcasted = Expression.TypeAs(p, targetType); 
        var pr = Expression.PropertyOrField(pcasted, targetPropertyName);
        var e = Expression.Equal(pr, Expression.Constant(sourceValue));
        var lambda = Expression.Lambda<Func<object, bool>>(e, p);
        var func = lambda.Compile();
        var obj = new Bar { AnotherName = "AName" };
        var res = func(obj);
    }
