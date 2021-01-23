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
            int detailHash = 0;
            unchecked
            {
                detailHash = obj.DocumentItemDetails
                                .Sum(d => detailHash * 17 + d.DetailAccountId);
            }
            return hash + detailHash;
        }
    }
