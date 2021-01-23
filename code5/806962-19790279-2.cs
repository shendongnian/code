    class CableComparer : IEqualityComparer<Cable>
    {
        public bool Equals(Cable x, Cable y)
        {
            return (x.CablePropertyId == y.CablePropertyId && ...);
        }
        public int GetHashCode(Cable x) // If you won't create a valid GetHashCode based on values you compare on, Linq won't work properly
        {
            return x.CablePropertyId ...;
        }
    }
    var diffCables = sourceCables.Except(destinationCables, new CableComparer());
