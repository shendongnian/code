    public class MyObjectEqualityComparer : IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            if (x == null) {
                return y == null;
            } else {
                if (y == null) {
                    return false;
                } else {
                    return x.protocol == y.protocol;
                }
            }
        }
        
        public int GetHashCode(MyObject obj)
        {
            if (obj == null) {
                throw new ArgumentNullException("obj");
            }
            
            return obj.protocol.GetHashCode();
        }
    }
