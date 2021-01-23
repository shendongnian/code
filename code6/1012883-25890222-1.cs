    public class ByteArrayComparer: IEqualityComparer<SimplyClass>
    {
        public bool Equals(SimplyClass x, SimplyClass y)
        {
            if(x == null || y == null || x.ByteArray == null || y.ByteArray == null)
                return false;
            return x.ByteArray.SequenceEqual(y.ByteArray);
        }
        public int GetHashCode(SimplyClass obj)
        {
            unchecked
            {
                if (obj.ByteArray == null)
                {
                    return 0;
                }
                int hash = 17;
                foreach (byte b in obj.ByteArray)
                {
                    hash = hash * 31 + b;
                }
                return hash;
            }
        }
    }
