    class ReferenceValue<T>
    {
        public T Value { get; set; }
        public ReferenceValue()
        {
        }
        public ReferenceValue(T value)
        {
            this.Value = value;
        }
        public static implicit operator ReferenceValue<T>(T v)
        {
            return new ReferenceValue<T> { Value = v };
        }
        public static implicit operator T(ReferenceValue<T> r)
        {
            return r.Value;
        }
        // would be useful to override equality, == and comparison operators
        public override string ToString()
        {
            var val = this.Value;
            if (val != null)
            {
                return val.ToString();
            }
            else
            {
                return base.ToString();
            }
        }
    }
