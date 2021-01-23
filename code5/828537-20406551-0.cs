    class ZipComparer : IEqualityComparer<int> {
        public bool Equals(int x, int y) {
            return x / 100 == y / 100;
        }
        public int GetHashCode(int x) {
            return x / 100;
        }
    }
