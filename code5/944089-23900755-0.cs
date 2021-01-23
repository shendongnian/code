    foreach (var property in type.GetProperties()) {
        if (property.PropertyType.IsClass 
        && property.PropertyType.Assembly.FullName == type.Assembly.FullName) {
            // do something with property
        }
    }
