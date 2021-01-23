    class AClass : IInterface, IEquatable<AClass>
    {
        public bool Equals(AClass other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(this.PropA, other.PropA) && string.Equals(this.PropB, other.PropB);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (AClass)) return false;
            return Equals((AClass)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.PropA != null ? this.PropA.GetHashCode() : 0) * 397) ^ (this.PropB != null ? this.PropB.GetHashCode() : 0);
            }
        }
        public string PropA { get; protected set; }
        public string PropB { get; protected set; }
    }
