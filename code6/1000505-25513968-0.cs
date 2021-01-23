    public class Health
    {
        public int Hp { get; set; }
        public int MaxHp { get; set; }
    }
    
    public class Location // Or use an existing Point3D implementation.
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
    
    public class Player
    {
        public Location Location { get; set; }
        public Health Health { get; set; }
    }
