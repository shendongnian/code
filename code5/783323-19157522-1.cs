    class MyDoubleComparer : IEqualityComparer<double>
    {
        public bool Equals(double x, double y)
        {
            // your comparing logic here
        }
        
        public int GetHashCode(double obj)
        {
            throw new NotImplementedException();
        }
    }
