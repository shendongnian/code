    public abstract class EnumEx<T> where T : EnumEx<T>
    {
        private readonly string _displayValue;
        private readonly string _value;
        protected static ReadOnlyCollection<T> EnumExs;
        protected EnumEx(string displayValue, string value)
        {
            _displayValue = displayValue;
            _value = value;
        }
        public string DisplayValue
        {
            get { return _displayValue; }
        }
        public static T FromString(string option)
        {
            foreach (var enumEx in EnumExs.Where(enumEx => enumEx._value == option))
            {
                return enumEx;
            }
            Debug.WriteLine(string.Format("Exception in EnumEX FromString({0})", option));
            return null;
        }
        public override string ToString()
        {
            return _value ?? string.Empty;
        }
    }
