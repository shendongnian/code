    public class Auto<T> where T: struct
    {
        private T? _value;
        public Auto()
        {
            _value = default(T);
        }
        public Auto(T val)
        {
            _value = val;
        }
        public Auto(T? val)
        {
            _value = val;
        }
        public bool HasValue
        {
            get
            {
                return _value.HasValue;
            }
        }
        public T Value
        {
            get { return _value.HasValue ? _value.Value : default(T); }
        }
        public static implicit operator T(Auto<T> d)
        {
            return d._value.HasValue ? d._value.Value : default(T);
        }
        public static implicit operator Auto<T>(T d)
        {
            return new Auto<T>(d);
        }
        public static implicit operator T?(Auto<T> d)
        {
            return (d._value);
        }
        public static implicit operator Auto<T>(T? d)
        {
            return new Auto<T>(d);
        }
    }
