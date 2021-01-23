    public static class EnumExtentions
    {
        public static List<Enum> ToList(this Type type)
        {
            return Enum.GetValues(type)
                        .OfType<Enum>()
                        .ToList();
        }
    
        public static Dictionary<int, string> ToDictionary(this Type type)
        {
            return type.GetEnumValues().Cast<Enum>().ToDictionary(Convert.ToInt32, e => e.GetDescription());
        }
    
        public static List<KeyValuePair<int, string>> ToListOfKeyValuePair(this Type type)
        {
            return Enum.GetValues(type)
                        .OfType<Enum>()
                        .Select(e => new KeyValuePair<int, string>(Convert.ToInt32(e), e.GetDescription()))
                        .ToList();
        }
    
        public static string GetDescription(this Enum value)
        {
            return value.GetDescription(null);
        }
    
        public static string GetDescription(this Enum value, string defaultValue)
        {
            var allFields = value.GetType().GetFields();
            if (!allFields.Any())
                return defaultValue;
    
            var targetField = allFields.FirstOrDefault(fi => (fi.IsLiteral && (fi.GetValue(null).Equals(value))));
            if (targetField == null)
                return defaultValue;
    
            var attrib = targetField.GetCustomAttributes(typeof(EnumValueDescriptionAttribute), false)
                .OfType<EnumValueDescriptionAttribute>()
                .FirstOrDefault();
            return attrib == null ? defaultValue : attrib.StringValue;
        }
    }
