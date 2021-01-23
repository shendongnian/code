    public T Foo<T>(string value) 
    {
        var changeType = typeof(T);
        var convertType = IsNullable(changeType)
            ? new System.ComponentModel.NullableConverter(typeof(T)).UnderlyingType
            : changeType;
    
        if (string.IsNullOrEmpty(value) && IsNullable(changeType))
        {
            var defValue = Activator.CreateInstance(
                Nullable.GetUnderlyingType(changeType));
            return (T)defValue;
        }
        else
        {
            return (T)Convert.ChangeType(value, convertType);
        }
    }
