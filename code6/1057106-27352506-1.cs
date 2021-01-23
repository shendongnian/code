    class Program
    {
        static void Main(string[] args)
        {
            Point3D p1 = new Point3D(1, 1, 0.0);
            Point3D p2 = new Point3D(3, 3, 0.0);
            Vector3D v = p2 - p1;
            double offset = 5;
            Point3D p3 = TranslatePoint(p2, offset, v);
        }
        static Point3D TranslatePoint(Point3D point, double offset, Vector3D vector)
        {
            vector.Normalize();
            double _offset = offset / vector.Length;
            Vector3D _vector = vector * _offset;
            Matrix3D m = new Matrix3D();
            m.Translate(_vector);
            Point3D result = m.Transform(point);
            return result;
        }
    }
