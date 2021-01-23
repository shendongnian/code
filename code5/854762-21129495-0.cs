    // Shapes.cs
    public class Shape
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double W { get; set; }
        public double H { get; set; }
    }
    public class Rectangle : Shape { }
    public class Circle : Shape { }
    public class Triangle : Shape
    {
        public double Angle { get; set; }
    }
