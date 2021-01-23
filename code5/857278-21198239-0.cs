    public interface IDrawable
    {
        double x { get; set; }
        double y { get; set; }
        // ...
    }
    public class Beacon : IDrawable
    {
        public double x { get; set; }
        public double y { get; set; }
        public Beacon(string id, double x, double y)
        {
            // ...
            this.x = x;
            this.y = y;
        }
    }
