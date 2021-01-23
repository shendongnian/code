    public class Coordinate : IEquatable<Coordinate>
    {
        public double Latitide { get; set; }
        public double Longitude { get; set; }
        public bool Equals(Coordinate other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.Latitide == other.Latitide && this.Longitude == other.Longitude;
            }
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Coordinate);
        }
        public override int GetHashCode()
        {
            return this.Latitide.GetHashCode() ^ this.Longitude.GetHashCode();
        }
        public static bool operator ==(Coordinate value1, Coordinate value2)
        {
            if (!Object.ReferenceEquals(value1, null) && Object.ReferenceEquals(value2, null))
            {
                return false;
            }
            else if (Object.ReferenceEquals(value1, null) && !Object.ReferenceEquals(value2, null))
            {
                return false;
            }
            else if (Object.ReferenceEquals(value1, null) && Object.ReferenceEquals(value2, null))
            {
                return true;
            }
            else
            {
                return value1.Latitide == value2.Latitide && value1.Longitude == value2.Longitude;
            }
        }
        public static bool operator !=(Coordinate value1, Coordinate value2)
        {
            return !(value1 == value2);
        }
    }
