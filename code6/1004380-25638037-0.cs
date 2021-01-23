    public static T ParseEnum<T>(this string valueToParse) where T : struct, IConvertible
            {
                return EnumParse<T>(valueToParse);
            }
    
            private static T EnumParse<T>(object valueToParse) where T : struct, IConvertible
            {
                T defaultValue = default(T);
    
                if (valueToParse != null && Enum.IsDefined(typeof(T), valueToParse))
                {
                    try
                    {
                        return (T)valueToParse;
                    }
                    catch (Exception e)
                    {
                        Enum.TryParse<T>(valueToParse.ToString(), out defaultValue);
                    }
                }
    
                return defaultValue;
            }
