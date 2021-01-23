    public class UnexpectedEnumException : Exception
    {
        public UnexpectedEnumException(Type enumType, object unexpectedValue)
            : base(string.Concat("Unexpected ", enumType.Name, ": ", unexpectedValue))
        {
        }
        public static UnexpectedEnumException Create<TEnum>(TEnum unexpectedValue) where TEnum : struct, IConvertible, IFormattable, IComparable
        {
            return new UnexpectedEnumException(typeof (TEnum), unexpectedValue);
        }
    }
