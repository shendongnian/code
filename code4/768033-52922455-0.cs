    public class Transform
    {
        public Vector3 position
        {
            get
            {
                // it would be this if the matrix itself is in world space
                return new Vector3(matrix.m30, matrix.m31, matrix.m32);
            }
        }
    }
