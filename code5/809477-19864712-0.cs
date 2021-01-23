    public struct MyCar : IEquateable<MyCar>
    {
        public int id { get; set; }
        public string name { get; set; }
    
        public override bool Equals(object obj)
        {
            if(obj is MyCar == false)
                return false;
            return Equals((MyCar)obj);
        }
        public bool Equals(MyCar car)
        {
            return this.id.Equals(car.id) && this.name.Equals(car.name);
        }
    
        public int GetHashCode()
        {
            unchecked
            {
                int i = 17;
                i = i * 23 + id.GetHashCode();
                i = i * 23 + name.GetHashCode();
                return i;
            }
        }
    }
