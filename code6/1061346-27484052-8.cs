    class Program
    {
        static void Main(string[] args)
        {
            PointF[] points1 = new PointF[] 
            { 
                new PointF(1f, 0f),
                new PointF(0f, 1f),
                new PointF(1f, 1f),
                new PointF(2f, 2f),
            };
            PointF[] points2 = new PointF[]
            { 
                new PointF(1f, 0f),
                new PointF(0f, 1f),
                new PointF(1f, 1f),
                new PointF(2f, 2f),
            };
    
            PointF center = new PointF(2f, 2f);
    
            float priorLength = 4f;
            float newLength = 5f;
    
            float lengthRatio = newLength / priorLength;
    
            float rotationAngle = 45f;
    
            Transformation_old(points1, rotationAngle, center, lengthRatio);
            Transformation_new(points2, rotationAngle, center, lengthRatio);
               
            Console.ReadKey();
        }
    
        static void Transformation_old(PointF[] points, float rotationAngle, PointF center, float lengthRatio)
        {
            Rotate(points, rotationAngle, center);
    
            for (int i = 0; i < points.Length; i++)
            {
                var translation = GetPointOnLine(center, points[i], lengthRatio);
                points[i].X = translation.X;
                points[i].Y = translation.Y;
            }
        }
    
        static void Rotate(PointF[] points, float angle, PointF center)
        {
            using (Matrix m = new Matrix())
            {
                m.RotateAt(angle, center);
                m.TransformPoints(points);
            }
        }
    
        private static PointF GetPointOnLine(PointF origin, PointF point, float ratio)
        {
            return new PointF(
                origin.X + (point.X - origin.X) * ratio,
                origin.Y + (point.Y - origin.Y) * ratio);
        }
    
        // Uses only a single matrix and a single transformation:
        static void Transformation_new(PointF[] points, float rotationAngle, PointF center, float lengthRatio)
        {
            using (Matrix m = new Matrix())
            {
                m.RotateAt(rotationAngle, center, MatrixOrder.Prepend);
    
                // Replaces GetPointOnLine
                m.Translate(center.X, center.Y, MatrixOrder.Prepend);
                m.Scale(lengthRatio, lengthRatio, MatrixOrder.Prepend);
                m.Translate(-center.X, -center.Y, MatrixOrder.Prepend);
    
                m.TransformPoints(points);
            }
        }
    }
