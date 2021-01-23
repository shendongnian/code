    sealed class MyComparer : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
            if (x == null)
                return y == null;
            else if (y == null)
                return false;
            else
                return x.recId== y.recId&& x.Category == y.Category;
        }
    
        public int GetHashCode(A obj)
        {
            return obj.recId.GetHashCode();
        }
    }
