    public static class EnumHelper
    {
        public static IEnumerable<ValueName> GetItems<TEnum>() 
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("TEnum must be an Enumeration type");
            var res = from e in Enum.GetValues(typeof(TEnum)).Cast<Enum>()
                        select new ValueName() { Value = e, Name = e.ToString()};
            return res;
        }
    }
    public struct ValueName
    {
        public object Value { get; set; }
        public string Name { get; set; }
    }
