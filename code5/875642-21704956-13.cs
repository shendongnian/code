    public static class EnumExt
    {
        public static string Description(this Enum value)
        {
            var attr = (DescriptionAttribute)value.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault();
            return attr != null ? attr.Description : value.ToString();
        }
    }
