    internal class MultipartKey<T> {
        private readonly HashSet<T> items;
        private readonly int hashCode;
        public MultipartKey(IEnumerable<T> items) {
            this.items = new HashSet<T>(items);
            hashCode = this.items.Where(i => i != null)
               .Aggregate(0, (p, v) => p*31 + v.GetHashCode());
        }
        public override int GetHashCode() {
            return hashCode;
        }
        public override bool Equals(object obj) {
            if (obj == this) return true;
            var other = obj as MultipartKey<T>;
            if (other == null) return false;
            return items.SetEquals(other.items);
        }
    }
