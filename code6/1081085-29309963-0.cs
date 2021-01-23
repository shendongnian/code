    public static IList<int> ToIntList(this object values)
            {
                //try to convert using modified ChangeType which handles nullables
                try
                {
                    if (values == null) return new List<int>();
    
                    var charValues = values.ToType<string>();
                    return charValues.Split(',').Select(n => Convert.ToInt32(n)).ToList();
                }
                //if there is an exception then get the default value of parameterized type T
                catch (Exception)
                {
                    return new List<int>();
                }
            }
    
    internal static object ChangeType(object value, Type conversionType)
            {
                if (conversionType == null)
                {
                    throw new ArgumentNullException("conversionType");
                } 
    
                if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof (Nullable<>))
                {
                    if (value == null)
                    {
                        return null;
                    } 
                    var nullableConverter = new NullableConverter(conversionType);
                    conversionType = nullableConverter.UnderlyingType;
                }
                return Convert.ChangeType(value, conversionType);
            }
