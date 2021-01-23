    class SpecialtyDataEqualityComparer : IEqualityComparer<SpecialtyData>
    {
        public bool Equals(SpecialtyData lhs, SpecialtyData rhs)
        {
            return lhs.Name == rhs.Name;
        }
        public int GetHashCode(SpecialtyData p)
        {
            return p.Name.GetHashCode();
        }
    }
 
