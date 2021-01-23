    public class A : B, IEquatable<A>
    {
        public bool Equals(A other)
        {
           if (other == null || GetType() != other.GetType())
               return false;
           //your implementation
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as A);
        }
    
        public override int GetHashCode()
        {
            //your implementation
        }
    }
