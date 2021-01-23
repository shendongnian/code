    public class MyComparer : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y) {
            return x["DealPeriod"] == y.["DealPeriod"] && 
                x["CustomerNumber"] == y.["CustomerNumber"] && 
                x["LOB"] == y.["LOB"];
        }
        public int GetHashCode(DataRow obj) {
            return obj["DealPeriod"].GetHashCode() ^ 
                obj["CustomerNumber"].GetHashCode() ^ 
                obj["LOB"].GetHashCode();
        }
    }
