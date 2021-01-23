    RefTest obj = new RefTest();
    PropertyInfo[] props = obj.GetType().GetProperties();
    foreach (PropertyInfo prop in props)
    {
        object PropertyValue = prop.GetValue(obj, null);
        var relationBaseList = PropertyValue as IRelationBaseList;
        foreach (var relationBase in relationBaseList.Collection)
        { 
            // do something with it
        }
    }
