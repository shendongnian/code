    public class Shape
    {
        public const double PI = Math.PI;
        protected double x, y;
        public Shape()
        {
        }
        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual double Area()
        {
            return x * y;
        }
    }
    public class Circle : Shape
    {
        public Circle(double r) : base(r, 0)
        {
        }
        public override double Area()
        {
            return PI * x * x;
        }
    }
