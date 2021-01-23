    public abstract class Shape
    {
        public abstract void SayMyName();
    }
    public class Circle : Shape
    {
        public override void SayMyName()
        {
            Console.WriteLine("I'm a circle!");
        }
    }
    public class Rectangle : Shape
    {
        public override void SayMyName()
        {
            Console.WriteLine("I'm a rectangle!");
        }
    }
    public class Polygon : Shape
    {
        public override void SayMyName()
        {
            Console.WriteLine("I'm a polygon!");
        }
    }
