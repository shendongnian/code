    public abstract class DrawingObject
    {
        public abstract void Draw();
        public Color Color { get; set; }
        protected DrawingObject(DrawingObject other)
        {
            this.Color=other.Color;
        }
        protected DrawingObject(Color color) { this.Color=color; }
    }
    public abstract class RectangularObject : DrawingObject
    {
        public int Width { get; set; }
        public int Height { get; set; }
        protected RectangularObject(RectangularObject other)
            : base(other)
        {
            Height=other.Height;
            Width=other.Width;
        }
        protected RectangularObject(Color color, int width, int height)
            : base(color)
        {
            this.Width=width;
            this.Height=height;
        }
    }
    public class Circle : RectangularObject, ICloneable
    {
        public int Diameter { get; set; }
        public override void Draw()
        {
        }
        public Circle(Circle other)
            : base(other)
        {
            this.Diameter=other.Diameter;
        }
        public Circle(Color color, int diameter)
            : base(color, diameter, diameter)
        {
            Diameter=diameter;
        }
        #region ICloneable Members
        public Circle Clone() { return new Circle(this); }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
    public class Square : RectangularObject, ICloneable
    {
        public int Side { get; set; }
        public override void Draw()
        {
        }
        public Square(Square other)
            : base(other)
        {
            this.Side=other.Side;
        }
        public Square(Color color, int side)
            : base(color, side, side)
        {
            this.Side=side;
        }
        #region ICloneable Members
        public Square Clone() { return new Square(this); }
        object ICloneable.Clone()
        {
            return Clone();
        }
        #endregion
    }
    public static class Factory
    {
        public static T Clone<T>(this T other) where T : DrawingObject
        {
            Type t = other.GetType();
            ConstructorInfo ctor=t.GetConstructor(new Type[] { t });
            if (ctor!=null)
            {
                ctor.Invoke(new object[] { other });
            }
            return default(T);
        }
    }
