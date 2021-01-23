    public class RootObject
    {
        public Stationary_Osbtacles[] stationary_osbtacles { get; set; }
        public Moving_Obstacles[] moving_obstacles { get; set; }
    }
    
    public class Stationary_Osbtacles
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float cylinder_radius { get; set; }
        public float cylinder_height { get; set; }
    }
    
    public class Moving_Obstacles
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float altitude_msl { get; set; }
        public float sphere_radius { get; set; }
    }
