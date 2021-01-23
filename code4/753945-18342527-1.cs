    public T Compare<T>(T first, T second) where T : new()
    {
        T result = new T();
        Type t = typeof(T);
        PropertyInfo[] propertyInfoList =  t.GetProperties();
        foreach (PropertyInfo propertyInfo in propertyInfoList)
        {
            object value1 = propertyInfo.GetValue(first, null);
            object value2 = propertyInfo.GetValue(second, null);
            if (!object.Equals(value1, value2))
                propertyInfo.SetValue(result, value2, null);
        }
        
        return result;
    }
