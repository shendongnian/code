    public sealed class StringKey: IEquatable<StringKey>
    {
        public StringKey(string key)
        {
            Contract.Requires(key != null);
            _key = key;
            _hashCode = key.GetHashCode();
        }
        public override int GetHashCode()
        {
            return _hashCode;
        }
        public bool Equals(StringKey other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return (_hashCode == other._hashCode) && string.Equals(_key, other._key);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is StringKey && Equals((StringKey) obj);
        }
        public string Key
        {
            get
            {
                return _key;
            }
        }
        private readonly string _key;
        private readonly int    _hashCode;
    }
