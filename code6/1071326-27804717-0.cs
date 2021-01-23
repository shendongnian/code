    public class MultipartKey : IEquitable<MultipartKey> {
        private IList<string> parts;
        int hashCode;
        public MultipartKey(IEnumerable<string> parts) {
            this.parts = parts.OrderBy(s => s).ToList();
            hashCode = this.parts.Aggregate(0, (p, v) => 31*p + v.GetHashCode());
        }
        public override int GetHashCode() {
            return hashCode;
        }
        public override bool Equals(MultipartKey other) {
            return parts.SequenceEqual(other.Parts);
        }
    }
