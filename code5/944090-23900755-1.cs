    foreach (var property in type.GetProperties()) {
        if (property.PropertyType.IsClass 
        && !property.PropertyType.FullName.StartsWith("System.")) {
            // do something with property
        }
    }
