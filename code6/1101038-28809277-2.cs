    public static class EnumHelper
    {
        public static IEnumerable<T> GetEnumValues<T>()
            where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
