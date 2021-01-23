    object[] attributeReader(PropertyInfo prop)
    {
        return prop.GetCustomAttributes(true);
    }
    somemethod(PropertyInfo prop)
    {
        // ...
        object[] attrs = attributeReader(prop); // read ATTRs from PROP
        foreach (object attr in attrs) // scan the PROP's ATTRs
        {
            // check attr type, do something
        }
        // ...
    }
