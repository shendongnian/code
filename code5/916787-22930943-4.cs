    public class AComparerInsensitive : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
            if (x == null)
            {
                return y == null;
            }
            if (y == null)
            {
                return false;
            }
            if (x.Value2 != y.Value2)
            {
                return false;
            }
            return StringComparer.CurrentCultureIgnoreCase.Equals(
                x.Value1,
                y.Value1)
        }
        public int GetHashCode(A a)
        {
            if (a == null)
            {
                return 0;
            }
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + 
                    StringComparer.CurrentCultureIgnoreCase.GetHashCode(
                        a.Value1);
                hash = (hash * 23) + a.Value2;
                return hash;
            }
        }
    }
