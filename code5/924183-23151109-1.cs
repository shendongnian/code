        public class GeoCoordinate
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double altitude { get; set; }
        public Location location { get { return new Location(latitude, longitude, altitude); } }
    }
