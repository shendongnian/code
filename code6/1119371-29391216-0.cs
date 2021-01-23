    public struct EllipsisString
    {
        private string _value;
        public string Value {get { return _value; }}
        public EllipsisString(string value)
        {
            _value = value;
        }
        // implicit conversion from string so it is possible to just assign string to the property
        public static implicit operator EllipsisString(string value)
        {
            return new EllipsisString(value);
        }
        public static implicit operator string(EllipsisString original)
        {
            return SpecialMethod(original.Value);
        }
        public override string ToString()
        {
            return SpecialMethod(Value);
        }
        private static string SpecialMethod(string value)
        {
            return value + "...";
        }
    }
