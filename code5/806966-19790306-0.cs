    public class CableComparer : IEqualityComparer<Cable>
    {
        public bool Equals(Cable x, Cable y)
        {
            return x.CablePropertyId == y.CablePropertyId &&
                   x.TagNo == y.TagNo &&
                   x.CableRevision == y.CableRevision;
        }
    
        // If Equals() returns true for a pair of objects  
        // then GetHashCode() must return the same value for these objects. 
        public int GetHashCode(Cable x)
        {
            return x.CablePropertyId ^ 
                   x.TagNo.GetHashCode() ^ 
                   x.CableRevision.GetHashCode();
        }
    }
