    public class Position
    {
        [Range(-180, 180)]
        public double Longitude { get; set; }
        [Range(-90, 90)]
        public double Latitude { get; set; }
    }
