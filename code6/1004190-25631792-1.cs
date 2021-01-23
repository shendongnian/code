    // the good side is that you can use generic delegates for added type safety
    public delegate T SetHandler<T>(T source, object value);
    private static SetHandler<T> GetDelegate<T>(FieldInfo fieldInfo)
    {
        return (s, val) => 
        { 
            object obj = s; // we have to box before calling SetValue
            fieldInfo.SetValue(obj, val);
            return (T)obj; 
        };
    }
