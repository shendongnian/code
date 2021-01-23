      public class PositionBase
      {
        public DateTime GPSTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Speed { get; set; }    // [km/h]
        public float Course { get; set; }   // [°]
    }
