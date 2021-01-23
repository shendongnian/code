    /// <summary>
    /// Generic comparer by key selector
    /// </summary>
    public class KeySelectorComparer<T, TProperty> : Comparer<T> where TProperty : IComparable<TProperty>
    {
        private readonly Func<T, TProperty> keySelector;
        public KeySelectorComparer(Func<T, TProperty> keySelector)
        {
            if (keySelector == null)
                throw new ArgumentException("'keySelector' parameter can not be null.", "keySelector");
            this.keySelector = keySelector;
        }
        public override bool Equals(T x, T y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;
            return this.keySelector(x).Equals(this.keySelector(y));
        }
        public override int GetHashCode(T obj)
        {
            if (ReferenceEquals(obj, null)) return 0;
            return this.keySelector(obj).GetHashCode();
        }
        public int Compare(T x, T y)
        {
            if (x == null)
            {
                if (y == null)
                    return 0;
                return 1;
            }
            if (y == null)
                return -1;
            return 0;
        }
    }
