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
            get { return (2 * Length) + (2 * Width); }
        }
        public double Area
        {
            get { return Length * Width; }
        }
        public Rectangle()
        {
            Length = 1;
            Width = 1;
        }
    }
