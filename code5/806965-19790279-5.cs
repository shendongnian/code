    class CableComparer : IEqualityComparer<Cable>
    {
        public bool Equals(Cable x, Cable y)
        {
            return (x.CablePropertyId == y.CablePropertyId && ...);
        }
        public int GetHashCode(Cable x) // If you won't create a valid GetHashCode based on values you compare on, Linq won't work properly
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + x.CablePropertyID;
                hash = hash * 23 + ...
            }
            return hash;
        }
    }
    var diffCables = sourceCables.Except(destinationCables, new CableComparer());
