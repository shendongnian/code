    public struct MyCar : IEquatable<MyCar>
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool Equals(MyCar other)
        {
            return this.id == other.id;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is MyCar)) { return false; }
            return o.id == this.id;
        }
        public override int GetHashCode()
        {
            return this.id;
        }
    }
