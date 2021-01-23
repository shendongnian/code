    if(/*noted conditions in question*/)
    {
       Type itemType = propertyType.GetGenericArguments()[0];
       Type ThisClass = typeof(ClassName);
       MethodInfo mi = ThisClass.GetMethod("MyGenericMethod", BindingFlags.Instance | BindingFlags.NonPublic);
       MethodInfo miConstructed = mi.MakeGenericMethod(itemType);
       object[] args = { url };
       var result = miConstructed.Invoke(this, args);
    }
