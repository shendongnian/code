    struct DoubleNoNan
    {
        public readonly double Value;
        public DoubleNoNan(double value)
        {
            if (Double.IsNaN(value))
            {
                throw new Exception("NaN");
            }
            this.Value = value;
        }
        public static implicit operator double(DoubleNoNan value)
        {
            return value.Value;
        }
        public static implicit operator DoubleNoNan(double value)
        {
            return new DoubleNoNan(value);
        }
        public override bool Equals(object obj)
        {
            return this.Value.Equals(obj);
        }
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
