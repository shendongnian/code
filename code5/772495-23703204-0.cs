    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof (DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return value.ToString();
        }
        public static Dictionary<T, string> EnumToDictionary<T>()
        {
            var enumType = typeof(T);
            if (!enumType.IsEnum)
                throw new ArgumentException("T must be of type System.Enum");
            return Enum.GetValues(enumType)
                       .Cast<T>()
                       .ToDictionary(k => k, v => (v as Enum).GetDescription());
        }
    }
