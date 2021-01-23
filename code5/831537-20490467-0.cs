     public static T FailIfEnumIsNotDefined<T>(this object enumValue, string message = null) where T : struct
            {
                var enumType = typeof(T);
    
                if (!enumType.IsEnum)
                {
                    throw new ArgumentOutOfRangeException("...");
                }
                else if (!Enum.IsDefined(enumType, enumValue))
                {
                    throw new ArgumentOutOfRangeException("...");
                }
    
                return (T)Enum.Parse(enumType, enumValue.ToString());// (T)enumValue;
            }
