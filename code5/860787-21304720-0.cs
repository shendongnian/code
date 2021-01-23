    public class Location
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public override bool Equals(object obj)
        {
            if(obj == null)return false;
            if(object.ReferenceEquals(this, obj)) return true;
            Location l2 = obj as Location;
            if(l2 == null) return false;
            return Latitude == l2.Latitude && Longitude == l2.Longitude;
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Latitude.GetHashCode();
                hash = hash * 23 + Longitude.GetHashCode();
                return hash;
            }
        }
        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }
    }
