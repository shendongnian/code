    class XYZEqualityComparer : IEqualityComparer<XYZ>
    {
        public bool Equals(XYZ a, XYZ b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;            
        }    
    
        public int GetHashCode(XYZ x)
        {
            int hash = x.X ^ x.Y ^ x.Z;
            return hash .GetHashCode();
        }
    }
