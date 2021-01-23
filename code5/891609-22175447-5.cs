    public class CoinComparer : IEqualityComparer<CoinDetails>
    {
        public bool Equals(CoinDetails x, CoinDetails y)
        {
            if (x == null || y == null) return false;
            if(object.ReferenceEquals(x, y)) return true;
            return x.Denomination == y.Denomination && x.Design == y.Design;
        }
        public int GetHashCode(CoinDetails obj)
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (obj.Denomination ?? "").GetHashCode();
                hash = hash * 23 + (obj.Design ?? "").GetHashCode();
                return hash;
            }
        }                      
    }
