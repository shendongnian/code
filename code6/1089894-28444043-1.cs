    class FullNameEqualityComparer : IEqualityComparer<FullName>
    {
        public bool Equals(FullName x, FullName y)
        {
            return (x.First == y.First && x.Last == y.Last);
        }
        public int GetHashCode(FullName obj)
        {
            return obj.First.GetHashCode() ^ obj.Last.GetHashCode();
        }
    }
