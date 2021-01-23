    public static IEnumerable<TEnum> Values<TEnum>()
    where TEnum : struct,  IComparable, IFormattable, IConvertible
    {
        var enumType = typeof(TEnum);
        // Optional runtime check for completeness    
        if(!enumType.IsEnum)
        {
            throw new ArgumentException();
        }
    
        return Enum.GetValues(enumType).Cast<TEnum>();
    }
