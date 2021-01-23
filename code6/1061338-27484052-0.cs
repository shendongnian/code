    class Program
    {
        static void Main(string[] args)
        {
            PointF[] points = new PointF[] 
        { 
            new PointF(1, 0), 
            new PointF(0, 1) 
        };
    
            float angle = 90; // in degrees
            PointF center = new PointF(1, 1);
            Rotate(points, angle, center);
        }
    
        static void Rotate(PointF[] points, float angle, PointF center)
        {
            using (Matrix m = new Matrix())
            {
                m.RotateAt(angle, center);
                m.TransformPoints(points);
            }
        }
    
        static PointF TranslatePoint(PointF point, float offset, PointF vector)
        {
            float magnitude = (float)Math.Sqrt((vector.X * vector.X) + (vector.Y * vector.Y)); // = length
            vector.X /= magnitude;
            vector.Y /= magnitude;
            PointF translation = new PointF()
            {
                X = offset * vector.X,
                Y = offset * vector.Y
            };
            using (Matrix m = new Matrix())
            {
                m.Translate(translation.X, translation.Y);
                PointF[] pts = new PointF[] { point };
                m.TransformPoints(pts);
                return pts[0];
            }
        } 
    }
