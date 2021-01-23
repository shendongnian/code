    public class RecordComparer : IEqualityComparer<Record>
    {
        public bool Equals(Record x, Record y)
        {
            return x.Id == y.Id;
        }
        public int GetHashCode(Record obj)
        {
            return obj.GetHashCode();
        }
    }
