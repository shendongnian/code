    public static class StringExtensions
    {
        public static bool TryParse<TEnum>(this string toParse, out TEnum output)
            where TEnum : struct
        {
            return Enum.TryParse<TEnum>(toParse, out output);
        }
    }
