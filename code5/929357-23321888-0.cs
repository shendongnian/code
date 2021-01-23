    public static bool IsDefined(Type enumType, Object value)
    {
         if (enumType == null)
             throw new ArgumentNullException("enumType");                    
         return enumType.IsEnumDefined(value);
    }
