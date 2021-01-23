    public abstract class Shape {
        public abstract double GetArea();
    }
    
    public class Rectangle : Shape {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double GetArea() {
            return Height * Width;
        }
    }
    
    public class Oval : Shape {
        public double Radius { get; set; }
        public override double GetArea() {
            return ...;
        }    
    }
