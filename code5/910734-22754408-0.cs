    sealed class ArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x == null && y == null)
                return true;
            if (x != null && y != null)
                return x.SequenceEqual(y);
            return false;
        }
    
        public int GetHashCode(int[] obj)
        {
            return obj.Length;
        }
    }
