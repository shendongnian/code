    public object GetObjectType(object objectTypeName)
    {
        Type objecType = objectTypeName.GetType(); // objecType is String here
        return Activator.CreateInstance(objecType); // creation of String fails
    }
