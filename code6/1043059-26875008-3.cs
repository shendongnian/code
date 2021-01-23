    public class RecordComparer : IEqualityComparer<Record>
    {
        public bool Equals(Record x, Record y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            return x.RecordHash.Equals(y.RecordHash);
        }
        public int GetHashCode(Record obj)
        {
            return unchecked((int) obj.RecordHash);
        }
    }
