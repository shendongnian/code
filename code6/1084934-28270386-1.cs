    public class Circle
    {
        public Circle(double radius) { Radius = radius; }
        public double Radius { get; private set; }
        public double Area {
          get {
             return 2 * Math.PI * Radius * Radius;
          }
        }
     }
