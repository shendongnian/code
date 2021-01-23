    public class ColumnListComparer : IEqualityComparer<List<Column>>
    {
        public bool Equals(List<Column> x, List<Column> y)
        {
            if (x == null || y == null) return false;
            if (object.ReferenceEquals(x, y)) return true;
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<Column> obj)
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
