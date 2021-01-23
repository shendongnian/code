    public static class EnumExt
    {
        public static string GetDescription<T>(this T value)
        {
            var attr = typeof(T).GetCustomAttributes(typeof(DescriptionAttribute), false)
                .FirstOrDefault();
            return attr != null ? attr.Description : value.ToString();
        }
    }
