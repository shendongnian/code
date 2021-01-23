    public class OrgExIdEqualityComparer : IEqualityComparer<DataRow>
    {
        public bool Equals(DataRow x, DataRow y)
        {
            return x["OrgExId"].Equals(y["OrgExId"]);
        }
    
        public int GetHashCode(DataRow obj)
        {
            return obj["OrgExId"].GetHashCode();
        }
    }
