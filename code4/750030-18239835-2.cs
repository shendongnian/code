    public class MyComparer : IEqualityComparer<tblTradeSpend>
    {       
        public bool Equals(tblTradeSpend x, tblTradeSpend y) {
            return x.DealPeriod == y.DealPeriod && 
                x.CustomerNumber == y.CustomerNumber && 
                x.LOB == y.LOB;
        }
        public int GetHashCode(tblTradeSpend obj) {
            return obj.DealPeriod.GetHashCode() ^ 
                obj.CustomerNumber.GetHashCode() ^ 
                obj.LOB.GetHashCode();
        }
    }
