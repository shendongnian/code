    public static T Parse<T>(object value) where T : struct
    {
        return (T)Parse<T>(value, false);
    }
    
    public static T? Parse<T>(object value, bool nullable) where T : struct
    {
        T? enumValue = null;
        
        if ( ! typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an Enum type.");
        }
        else if (value == null || value == DBNull.Value)
        {
            // this is the key difference
            if ( ! nullable)
            {
                throw new ArgumentException("Cannot parse enum, value is null.");
            }
        }
        else if (value is string)
        {
            enumValue = (T)Enum.Parse(typeof(T), value.ToString());
        }
        else
        {
            enumValue = (T)Enum.ToObject(typeof(T), value);
        }
    
       return enumValue;
    }
