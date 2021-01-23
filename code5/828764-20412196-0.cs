    System.Reflection.PropertyInfo[] properties = entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
    foreach (System.Reflection.PropertyInfo propertyInfo in properties)
    {
        // ...
    }
