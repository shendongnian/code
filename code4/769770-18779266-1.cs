    public abstract class Shape
    {
        public abstract int CalcArea();
    }
    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public override int CalcArea()
        {
            return Height * Width;
        }
    }
    public class Circle : Shape
    {
        public float Radius { get; set; }
        public override int CalcArea()
        {
            return Math.PI * (Radius * Radius);
        }
    }
