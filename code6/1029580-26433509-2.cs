    public struct PositiveInteger
    {
        public PositiveInteger(uint value)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException();
            _value = value;
        }
        public uint Value { get { return _value == 0 ? 1 : _value; } }
        private readonly uint _value;
        public static implicit operator PositiveInteger(uint value)
        {
            return new PositiveInteger(value);
        }
        public static implicit operator uint(PositiveInteger value)
        {
            return value.Value;
        }
        public static PositiveInteger operator +(PositiveInteger value1, PositiveInteger value2)
        {
            var result = value1.Value + value2.Value;
            if (result < value1.Value || result < value2.Value)
            {
                throw new ArgumentOutOfRangeException();    //overflow
            }
            return result;
        }
        public static PositiveInteger operator -(PositiveInteger value1, PositiveInteger value2)
        {
            if (value1.Value < value2.Value) throw new ArgumentOutOfRangeException();
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
            return (int)Value;
        }
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
