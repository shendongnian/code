    Type t = myObject.GetType();
    PropertyInfo prop = t.GetProperty("Items");
    if (prop == null)
    {
        // handle this error...
    }
    object list = prop.GetValue(myObject);
