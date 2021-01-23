    public static IEnumerable<T> Parse<T>(this Enum value, Func<Enum, T> expression)
    {
    
        Type type = value.GetType();
    
        IEnumerable<Enum> values;
    
        if (type.GetCustomAttributes(typeof(FlagsAttribute), false).Any())
            values = Enum.GetValues(type).Cast<Enum>().Where(value.HasFlag);
        else
            values = new List<Enum> { value };
    
        return values.Select(expression);
    
    } // Parse 
