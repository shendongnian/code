    foreach(var proparty in properties)
    {
        var value = property.GetValue(this);
        var entityType = property.PropertyType.GetGenericArguments().First();
        var callSaveChanges = this.GetType()
                                  .GetMethod("CallSaveChanges", BindingFlags.NonPublic | BindingFlags.Static);
    
        var constructedCallSaveChanges = callSaveChanges.MakeGenericMethod(entityType );
    
        constructedCallSaveChanges.Invoke(null, BindingFlags.NonPublic | BindingFlags.Static, null, new object[]{ value }, CultureInfo.InvariantCulture);
    }
