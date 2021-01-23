    public static class Enum<TEnum> where TEnum : struct, IComparable, IFormattable, IConvertible
    {
        public static IEnumerable<TEnum> GetAll()
        {
            var t = typeof(TEnum);
            if (!t.IsEnum)
                throw new ArgumentException();
            return Enum.GetValues(t).Cast<TEnum>();
        }
    }
