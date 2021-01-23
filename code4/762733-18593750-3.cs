    // Use Reflection (ProperyInfo) to reference the property
    PropertyInfo pi = instance.GetType()
        .GetProperty(propName);
    // then use GetValue to access it (and cast as necessary)
    String valueOfBar = (String)pi.GetValue(instance);
