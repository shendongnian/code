    public abstract class Shape
    {
        public abstract void CalcArea();
    }
    public class Rectangle : Shape
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public override void CalcArea()
        {
            Console.WriteLine(Height * Width);
        }
    }
    public class Circle : Shape
    {
        public float Radius { get; set; }
        public override void CalcArea()
        {
            Console.WriteLine(Math.PI * (Radius * Radius));
        }
    }
