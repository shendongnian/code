    var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
    var propertyInfo = typeof(MyClass).GetProperty("Components", flags);
    // only go to the declaring type if you need to
    if (!propertyInfo.CanWrite)
        propertyInfo = propertyInfo.DeclaringType.GetProperty("Components", flags);
