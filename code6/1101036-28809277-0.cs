    public static EnumHelper
    {
        public static IEnumerable<T> GetEnumValues<T>()
            where T : struct, IConvertible
        {
            Type enumType = typeof(T);
            FieldInfo[] fields = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < fields.Length; i++)
                yield return (T)fields[i].GetValue(null);
        }
    }
