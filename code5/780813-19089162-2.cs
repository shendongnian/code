    public class AccDocumentItemComparer : IEqualityComparer<AccDocumentItem>
    {
        public bool Equals(AccDocumentItem x, AccDocumentItem y)
        {
            if (x == null || y == null)
                return false;
            if (object.ReferenceEquals(x, y))
                return true;
            if (x.AccountId != y.AccountId)
                return false;
            return x.GetHashCode() == y.GetHashCode();
        }
        public int GetHashCode(AccDocumentItem obj)
        {
            if (obj == null) return int.MinValue;
            int hash = obj.AccountId.GetHashCode();
            if (obj.DocumentItemDetails == null)
                return hash;
            return hash + obj.DocumentItemDetails.Sum(d => d.DetailAccountId);
        }
    }
