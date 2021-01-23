    public struct BlindIdentityToken : IEquatable<BlindIdentityToken>
    {
        Object o;
        public BlindIdentityToken(Object obj)
        {
            o = obj;
        }
        public override int GetHashCode()
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(o);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(BlindIdentityToken))
                return false;
            return ((BlindIdentityToken)obj).o == o;
        }
        public bool Equals(BlindIdentityToken other)
        {
            return o == other.o;
        }
    }
