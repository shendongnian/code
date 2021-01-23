    public class HitObject : IEquatable<HitObject>
    {
        public string V1;
        public float V2;
        public float V3;
        public bool Equals(HitObject other)
        {
            return this.V1 == other.V1;
        }
    }
