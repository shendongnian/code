    public static EnumHelper
    {
        public static IEnumerable<T> GetEnumValues<T>()
            where T : struct, IConvertible
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
