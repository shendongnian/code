    class Cylinder
    {
        public double Radius;
        public double Height;
        public double GetVolume()
        {
             return Math.PI * Radius * Radius * Height;
        }
        // Constructor
        public Cylinder(double radius, double height)
        {
             this.Radius = radius;
             this.Height = height;
        }
    }
