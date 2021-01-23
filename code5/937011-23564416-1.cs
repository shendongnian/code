    public class EnumHelper
    {
        public static  T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
    	    Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val;
    	    return Enum.TryParse<T>(str, true, out val) ? val : default(T);
        }
    
        public static T GetEnumValue<T>(int intValue) where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
    		
    	    return (T)Enum.ToObject(enumType, intValue);
        }
    }
