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
            return x.DocumentItemDetails
                    .Select(d => d.DetailAccountId).OrderBy(i => i)
                    .SequenceEqual(y.DocumentItemDetails
                                    .Select(d => d.DetailAccountId).OrderBy(i => i));
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
                foreach (var detID in obj.DocumentItemDetails.Select(d => d.DetailAccountId))
                    detailHash = detailHash * 23 + detID;
            }
            return hash + detailHash;
        }
    }
