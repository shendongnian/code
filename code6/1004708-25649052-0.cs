    class Mutable<T>
    {
        public Mutable(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
    }
