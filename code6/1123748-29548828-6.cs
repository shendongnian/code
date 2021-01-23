    public class StationaryObstacle
    {
        public double latitude { get; set; }
        public double cylinder_height { get; set; }
        public double cylinder_radius { get; set; }
        public double longitude { get; set; }
    }
    
    public class MovingObstacle
    {
        public double latitude { get; set; }
        public double sphere_radius { get; set; }
        public double altitude_msl { get; set; }
        public double longitude { get; set; }
    }
    
    public class RootObject
    {
        public List<StationaryObstacle> stationary_obstacles { get; set; }
        public List<MovingObstacle> moving_obstacles { get; set; }
    }
