    public class CoinComparer : IEqualityComparer<CoinDetails>
    {
        public bool Equals(CoinDetails x, CoinDetails y)
        {
            if (x == null || y == null) return false;
            if(object.ReferenceEquals(x, y)) return true;
            return x.Equals(y);
        }
        public int GetHashCode(CoinDetails obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
    }
