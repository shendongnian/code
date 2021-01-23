    // Vector3 defined elsewhere with .x, .y and .z fields
    class VectorAlgebra
    {
        public static Vector3 Subtract(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x-b.x, a.y-b.y, a.z-b.z);
        }
        public static Vector3 Scale(float f, Vector3 a)
        {
            return new Vector3(f*a.x, f*a.y, f*a.z);
        }
        public static float Dot(Vector3 a, Vector3 b)
        {
            return (a.x*b.x)+(a.y*b.y)+(a.z*b.z);
        }
        public static Vector3 Projection(Vector3 a, Vector3 b)
        {
            return Scale(Dot(a, b)/Dot(b, b), b);
        }
        public static Vector3 Rejection(Vector3 a, Vector3 b)
        {
            return Subtract(a, Projection(a, b));
        }
        static void Main(string[] args)
        {
            var A=new Vector3(5, 5, 0);
            var B=new Vector3(0, 10, 0);
            var C=Rejection(A, B);
            // C = { 5,0,0}, expected answer from math {5,5,0}-0.5*{0,10,0}
        }
    }
