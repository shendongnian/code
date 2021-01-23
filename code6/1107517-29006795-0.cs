    class Program
    {
        static void Main(string[] args)
        {
            int n = 22; //the number of points
            float radius = 22f;
            Vector3 vector = new Vector3(radius, 0, 0); //the vector you keep rotating
            Vector3 center = new Vector3(33,33,33); //center of the circle
            float angle = (float)Math.PI * 2 / (float)n;
            Vector3[] points = new Vector3[n];
            
            Matrix rotation = Matrix.RotationZ(angle);
            for (int i = 0; i < n; i++)
            {
                points[i] = vector + center;
                
                vector.TransformNormal(rotation);
            }
        }
    }
