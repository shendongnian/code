    double[] items = new[] { 1d, 2d, 3d };
    var dups = items.GroupBy(i => i, new MyDoubleComparer())
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key);
    
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
