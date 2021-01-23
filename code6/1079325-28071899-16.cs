    public class Rectangle
    {
        private double length;
        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        private double width;
        public double Width
        {
            get { return width; }
            set { width = value; }
        }
        public double Perimeter
        {
            get { return (2.0 * Length) + (2.0 * Width); }
        }
        public double Area
        {
            get { return Length * Width; }
        }
        public Rectangle()
        {
            Length = 1.0;
            Width = 1.0;
        }
    }
