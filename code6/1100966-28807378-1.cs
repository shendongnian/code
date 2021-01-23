    // get entity prop value
    var entityValue =
        (obj.GetType()
            .GetProperty("Entity", 
               BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public)
            .GetValue(obj));
    // get prop value
    var prop1Value =
        entityValue.GetType()
                   .GetProperty("prop1", 
                      BindingFlags.FlattenHierarchy | 
                      BindingFlags.Instance | 
                      BindingFlags.Public)
                   .GetValue(entityValue);
