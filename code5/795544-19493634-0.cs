    public class IntArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x.Length != y.Length)
            {        
                return false;
            }
            return x.Zip(y, (v1, v2) => v1 == v2).All(b => b);
        }
    
        public int GetHashCode(int[] x)
        {
            return 0;
        }
    }
