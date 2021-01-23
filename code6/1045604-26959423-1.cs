    public struct Vector3
    {
        public readonly double x, y, z;
        public Vector3(double x, double y, double z)
        {
            this.x=x;
            this.y=y;
            this.z=z;
        }
        public double Dot(Vector3 other)
        {
            return x*other.x+y*other.y+z*other.z;
        }
        public Vector3 Scale(double factor)
        {
            return new Vector3(factor*x, factor*y, factor*z);
        }
        public Vector3 Add(Vector3 other)
        {
            return new Vector3(x+other.x, y+other.y, z+other.z);
        }
        public static Vector3 operator+(Vector3 a, Vector3 b) { return a.Add(b); }
        public static Vector3 operator-(Vector3 a) { return a.Scale(-1); }
        public static Vector3 operator-(Vector3 a, Vector3 b) { return a.Add(-b); }
        public static Vector3 operator*(double f, Vector3 a) { return a.Scale(f); }
        public static Vector3 operator/(Vector3 a, double d) { return a.Scale(1/d); }
        public static double operator*(Vector3 a, Vector3 b) { return a.Dot(b); }
        public Vector3 Projection(Vector3 other)
        {
            // (scalar/scalar)*(vector) = (vector)
            return (other*this)/(this*this)*other;
        }
        public Vector3 Rejection(Vector3 other)
        {
            // (vector)-(vector) = (vector)
            return this-Projection(other);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var A=new Vector3(5, 5, 0);
            var B=new Vector3(0, 10, 0);
            var C=A.Rejection(B);
            // C = { 5,-5,0}
        }
    }
