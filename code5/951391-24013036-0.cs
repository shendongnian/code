    public class TableComparer : IEqualityComparer<PropertyData>
    {
        public bool Equals(PropertyData x, PropertyData y)
        {
            return x.id == y.id;
        }
        public int GetHashCode(PropertyData pData)
        {
            return pData.id.GetHashCode();
        }
    }
