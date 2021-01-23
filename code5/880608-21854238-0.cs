    static class EnumEx
    {
        public static string ToJsonString(this Type enumType)
        {
            if(!enumType.IsEnum)
                throw new ArgumentException("Type should be enum");
            return /* create json string from enum type */
        }
    }
