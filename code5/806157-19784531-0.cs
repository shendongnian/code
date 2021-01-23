    public class SizeD
    {
        public double Width { get; private set; };
        public double Height { get; private set; };
    
        /// <summary>
        /// Creates a new instance of SizeD
        /// </summary>
        public SizeD(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
