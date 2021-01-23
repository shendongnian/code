    // note the attributeReader is now a field, not function
    Func<PropertyInfo, object[]> attributeReader = defaultAttributeReader;
    static object[] defaultAttributeReader(PropertyInfo prop)
    {
        return prop.GetCustomAttributes(true);
    }
    // and your test setup
    var t = ... // that ORIGNAL object
    t.attributeReader = customReaderForTheTest; // change the reader on the fly
    // that's the reader-function to use in THIS TEST setup
    static object[] customReaderForTheTest(PropertyInfo prop)
    {
        if(prop.Name = "ShoeSize") return null; // crash when I say so! muhaHAHAhaa!
        return prop.GetCustomAttributes(true);
    }
