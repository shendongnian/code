    class Program
    {
        static void Main(string[] args)
        {
            {
                PointF p1 = new PointF(1f, 1f);
                PointF p2 = new PointF(3f, 3f);
    
                PointF v = new PointF()
                {
                    X = p2.X - p1.X,
                    Y = p2.Y - p1.Y
                };
                float offset = 5;
                PointF p3 = TranslatePoint(p2, offset, v);
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
