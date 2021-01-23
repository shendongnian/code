    public static class EnumExt
    {
        public static string GetDescription<T>(this T value)
        {
            var attrs = (DescriptionAttribute)typeof(T).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length == 0 ? value.ToString() : attr[0].Description;
        }
    }
