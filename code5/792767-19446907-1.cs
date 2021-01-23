    public class PositionBase
    {
        public int Id { get; set; }
        public DateTime GPSTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Speed { get; set; }    // [km/h]
        public float Course { get; set; }   // [°]
        [ForeignKey("Id")]
        [Required]
        public virtual UnifiedPositionMessage UnifiedPositionMessage { get; set; }
    }
