    public static class EnumUtil<TEnum> where TEnum : struct
    {
        public static readonly Dictionary<TEnum, string> _cache;
        static EnumUtil()
        {
            _cache = Enum
                .GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .ToDictionary(x => x, x => string.Format("{0}.{1}", typeof(TEnum).Name, x));
        }
        public static string AsString(TEnum value)
        {
            return _cache[value];
        }
    }
