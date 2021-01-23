     public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumVal) where T : struct
        {
            Type type = enumVal.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("Must be enum type","enumVal");
            }
            MemberInfo[] memberInfo = type.GetMember(enumVal.ToString());
            if (memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumVal.ToString();
        }
    }
