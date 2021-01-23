    public object GetObjectType(string objectTypeName)
    {
        Type objecType = Type.GetType(objectTypeName);
        return Activator.CreateInstance(objecType);
    }
