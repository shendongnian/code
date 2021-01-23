    private class PriceRange<T> : IEquatable<PriceRange<T>>
    {
        public T Min { get; set; }
        public T Max { get; set; }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + Min.GetHashCode();
                hash = hash * 31 + Max.GetHashCode();
                return hash;
            }
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as PriceRange<T>);
        }
        public bool Equals(PriceRange<T> other)
        {
            if (other == null) return false;
            if (!Min.Equals(other.Min)) return false;
            if (!Max.Equals(other.Max)) return false;
            return true;
        }
    }
