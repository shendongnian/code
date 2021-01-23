    public class MyComparer : IEqualityComparer<int?> {
        public bool Equals(int? x, int? y) {
            if (x == null || y == null) {
                return false;
            }
            return x.Value == y.Value;
        }
        public int GetHashCode(int? obj) {
            return obj.GetHashCode(); // Works even if obj is null :-)
        }
    }
