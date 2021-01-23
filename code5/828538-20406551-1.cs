    class ZipComparer : IEqualityComparer<string> {
        public bool Equals(string x, string y) {
            return x.Remove(3) == y.Remove(3);
        }
        public int GetHashCode(string x) {
            return x.Remove(3).GetHashCode();
        }
    }
