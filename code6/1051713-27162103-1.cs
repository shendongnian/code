    public class Vector3D<T>
    {
        public T x; 
        public T y; 
        public T z;
        public Vector3D()
        {
        }
        public Vector3D(T a, T b, T c)
        {
            x = a; y = b; z = c;
        }
        public override string ToString()
        {
            //return base.ToString();
            return String.Format("({0} {1} {2})", x , y , z);
        }
        public Vector3D<double> operator+( Vector3D<double> right)
        {
            Vector3D<double> vd = new Vector3D<double>() { x = 0, y = 0, z = 0};
            vd.x = left.x + right.x;
            vd.y = left.y + right.y;
            vd.z = left.z + right.z;
            return vd;
        }
    }
