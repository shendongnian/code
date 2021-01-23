    public class Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }
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
