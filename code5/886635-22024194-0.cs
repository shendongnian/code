    public object this[int index]
    {
        Type myType =typeof(MyTypeClass);
        PropertyInfo[] myProperties = 
            myType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        object result = myProperties[myIndex].GetValue(myClassInstance, null);
        return result;
    }
