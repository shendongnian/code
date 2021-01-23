    class TrimmedEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x == null && y != null || x != null && y == null)
                return false;
            if (x == null && y == null)
                return true;
            return x.Trim() == y.Trim();
        }
        public int GetHashCode(string obj)
        {
            return obj != null ? obj.GetHashCode() : 0;
        }
    }
