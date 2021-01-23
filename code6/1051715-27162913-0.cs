    abstract class Vector3D<T>
    {
        public readonly T x;
        public readonly T y;
        public readonly T z;
        public Vector3D() { }
        public Vector3D(T x, T y, T z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public abstract Vector3D<T> Add(Vector3D<T> right);
    }
    class Vector3DDouble : Vector3D<double>
    {
        public Vector3DDouble() { }
        public Vector3DDouble(double x, double y, double z)
            : base(x, y, z)
        { }
        public override Vector3D<double> Add(Vector3D<double> right)
        {
            return new Vector3DDouble(x + right.x, y + right.y, z + right.z);
        }
    }
