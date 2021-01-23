    class NullStringsAreDistinctComparer : IEqualityComparer<string> {
        public bool Equals(string x, string y) {
            return (x == null) ? y != null : x.Equals(y, StringComparison.InvariantCulture);
        }
        public int GetHashCode(string obj) {
            return (obj == null) ? 0 : obj.GetHashCode();
        }
    }
