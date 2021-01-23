    class EqualityComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            if (x.Where((t, i) => t != y[i]).Any())
            {
                return false;
            }
            return true;
        }
    
        public int GetHashCode(string[] obj)
        {
            return obj.GetHashCode(); 
        }
    }
