    public class Ellipse
    {
        public PointF Center { get; set; }
        public Brush Brush { get; set; }
        public float Diameter { get; set; }
        public float DiameterDelta { get; set; }
        public Ellipse(float x, float y)
        {
            Center = new PointF(x, y);
            Brush = Brushes.Blue;
            Diameter = 5;
            DiameterDelta = 1;
        }
    }
    
