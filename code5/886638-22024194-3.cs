    public static Property IndexedProperty(this object obj, int index)
    {
        Type myType = obj.GetType();
        PropertyInfo[] myProperties = 
            myType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        return myProperties[myIndex];
    }
