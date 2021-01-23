    public class hitOBject
    {
        public string v1;
        public float v2;
        public float v3;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return ((hitOBject)obj).v1 == this.v1;
        }
        public override int GetHashCode()
        {
            return (v1 != null ? v1.GetHashCode() : 0);
        }
    }
