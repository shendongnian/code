    var assembly = typeof(NameOfAnyClassInTheAssembly).Assembly;
    string typeName = NameOfClass;
    var type = assembly.GetType(typeName);
    // Create an instance of this type
    var instance = Activator.CreateInstance(type);
    // Get the property of this type
    var property = type.GetProperty("NameOfProperty");
    // Fetch the property value
    var propertyValue = property.GetValue(instance, null);
