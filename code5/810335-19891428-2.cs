    public sealed class MyObjectByProtocolComparer: IEqualityComparer<MyObject>
    {
        public bool Equals(MyObject x, MyObject y)
        {
            return x.protocol.Equals(y.protocol);
        }
    
        public int GetHashCode(MyObject obj)
        {
            return obj.protocol.GetHashCode();
        }
    }
