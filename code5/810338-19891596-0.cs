    public class MyObject : IEquatable<MyObject>
    {
        public sealed override bool Equals(object other)
        {
            return Equals(other as MyObject);
        }
        
        public bool Equals(MyObject other)
        {
            if (other == null) {
                return false;
            } else {
                return this.protocol == other.protocol;
            }
        }
        
        public override int GetHashCode()
        {
            return protocol.GetHashCode();
        }
    }
