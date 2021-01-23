    public class A : B // no interfaces
    {
    }
    public class AEqualComparer : IEqualityComparer<A>
    {
        public bool Equals(A x, A y)
        {
           //your implementation
        }
        public int GetHashCode(A x)
        {
            //your implementation
        }
    }
