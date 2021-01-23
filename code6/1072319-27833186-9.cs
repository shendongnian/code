        public static class EnumUtils
        {
            public static string StringValueOf(Enum value)
            {
                var fi = value.GetType().GetField(value.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
                return value.ToString();
            }
        
            public static T EnumValueOf<T>(string enumStr)
            {
                string[] names = Enum.GetNames(typeof(T));
                foreach (var name in names)
                {
                    var enumVal = (Enum) Enum.Parse(typeof (T), name);
                    if (string.Compare(StringValueOf(enumVal), enumStr, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return (T)Enum.Parse(typeof(T), name);
                    }
                }
        
                throw new ArgumentException("The string is not a description or value of the specified enum.");
            }
        }
