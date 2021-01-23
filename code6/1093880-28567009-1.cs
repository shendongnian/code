    class TempClassEqualityComparer : IEqualityComparer<TempClass>
    {
        public bool Equals(TempClass x, TempClass y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
	
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            // For comparison check both combinations
            return (x.One == y.One &&  x.Two == y.Two) || (x.One == y.Two && x.Two == y.One);
        }
	
        public int GetHashCode(TempClass x)
        {
            if (Object.ReferenceEquals(x, null)) return 0;
            return x.One.GetHashCode() ^ x.Two.GetHashCode();
        }
    }
