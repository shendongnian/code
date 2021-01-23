    public object this[int index]
    {
        Type myType = this.GetType();
        PropertyInfo[] myProperties = 
            myType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        object result = myProperties[myIndex].GetValue(myClassInstance, null);
        return result;
    }
