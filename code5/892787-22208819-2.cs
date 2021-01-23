    public class ColumnListComparer : IEqualityComparer<IEnumerable<Column>>
    {
        public bool Equals(IEnumerable<Column> x, IEnumerable<Column> y)
        {
            if (x == null || y == null) return false;
            if (object.ReferenceEquals(x, y)) return true;
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IEnumerable<Column> obj)
        {
            unchecked
            {
                int hash = 17;
                foreach(Column col in obj)
                {
                    hash = hash * 23 + (col == null ? 0 : col.GetHashCode());
                }
                return hash;
            }
        }
    }
