    public struct RoundedDouble : IEquatable<RoundedDouble>, IComparable<RoundedDouble>
    {
        public readonly double Value;
    
        public RoundedDouble(double value)
        {
            Value = Math.Round(value);
        }
    
        public static implicit operator RoundedDouble(double value)
        {
            return new RoundedDouble(value);
        }
    
        public static implicit operator double(RoundedDouble wrapper)
        {
            return wrapper.Value;
        }
    
        public int GetHashCode()
        {
            return Value.GetHashCode();
        }
    
        public bool Equals(object other)
        {
            if (other is RoundedDouble)
                return ((RoundedDouble)other).Value == Value;
    
            return false;
        }
    
        public string ToString()
        {
            return Value.ToString();
        }
    
        // Add your operators here, and implement the interfaces
    }
