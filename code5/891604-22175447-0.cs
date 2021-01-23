    public class CoinDetails 
    {
        private string Denomination;
        private string Design;
        private CoinSide Side;
        public override bool Equals(object obj)
        {
            CoinDetails c2 = obj as CoinDetails;
            if (c2 == null)
                return false;
            return Denomination == c2.Denomination && Design == c2.Design;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Denomination.GetHashCode();
                hash = hash * 23 + Design.GetHashCode();
                return hash;
            }
        }
    }
