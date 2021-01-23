    public class NTuple<T> : IEquatable<NTuple<T>>
    {
        public NTuple(IEnumerable<T> values)
        {
            _values = values.ToArray();
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == null)
                return false;
            return Equals(obj as NTuple<T>);
        }
        public bool Equals(NTuple<T> other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (other == null)
                return false;
            var length = _values.Length;
            if (length != other._values.Length)
                return false;
            for (var i = 0 ; i < length; ++i)
                if (!Equals(_values[i], other._values[i]))
                    return false;
            return true;
        }
        public override int GetHashCode()
        {
            var hc = 17;
            foreach (var value in _values)
                hc = hc*37 + (!ReferenceEquals(value, null) ? value.GetHashCode() : 0);
            return hc;
        }
        private readonly T[] _values;
    }
