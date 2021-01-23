    var classType = ... // current class type 
    PropertyInfo[] props = classType.GetProperties();
    foreach (PropertyInfo prop in props)
    {
        // here ... just find out if this property
        // is candidate for Bag mapping
        var isBagCandidate = prop.PropertyType.GenericTypeArguments.Length > 0
            && !prop.PropertyType.IsValueType
            && ... // these checks should be adjusted
            ;
        if (!isBagCandidate)
        {
            continue; // do not continue to Bag mapping
        }
        // now we just get reference to our method defined above
        MethodInfo method = typeof(MyClassMapping).GetMethod("CreateBag");
        MethodInfo generic = method.MakeGenericMethod(
                                               prop.PropertyType.GenericTypeArguments[0]);
        // and call it, with needed params
        generic.Invoke(this, new object[] { prop, classType });
    }
