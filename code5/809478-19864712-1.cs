    public struct MyCar : IEquatable<MyCar>
    {
        public int id { get; set; }
        public string name { get; set; }
        private static readonly StringComparer stringComparer = StringComparer.Ordinal;
        public override bool Equals(object obj)
        {
            if (obj is MyCar == false)
                return false;
            return Equals((MyCar)obj);
        }
        public bool Equals(MyCar car)
        {
            return this.id.Equals(car.id) && stringComparer.Equals(this.name,car.name);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int i = 17;
                i = i * 23 + id.GetHashCode();
                i = i * 23 + stringComparer.GetHashCode(name);
                return i;
            }
        }
    }
