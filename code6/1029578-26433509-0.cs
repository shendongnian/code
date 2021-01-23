    public struct PositiveInteger
    {
        public PositiveInteger(int value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException();
            _value = value;
        }
        public int Value { get { return _value == 0 ? 1 : _value; } }
        private readonly int _value;
        public static implicit operator PositiveInteger(int value)
        {
            return new PositiveInteger(value);
        }
        public static implicit operator int(PositiveInteger value)
        {
            return value.Value;
        }
        public static PositiveInteger operator +(PositiveInteger value1, PositiveInteger value2)
        {
            return value1.Value + value2.Value;
        }
        public static PositiveInteger operator -(PositiveInteger value1, PositiveInteger value2)
        {
            return value1.Value - value2.Value;
        }
        public override bool Equals(object obj)
        {
            if (obj is PositiveInteger == false) return false;
            return Equals((PositiveInteger)obj);
        }
        public bool Equals(PositiveInteger other)
        {
            return Value == other.Value;
        }
        public override int GetHashCode()
        {
            return Value;
        }
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
