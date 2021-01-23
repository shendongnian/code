    public class Transform
    {
        public Vector3 position
        {
            get
            {
                // it would be this if the matrix itself is in world space
                return new Vector3(matrix.m30, matrix.m31, matrix.m32);
            }
            set
            {
                // it probably doesn't use these mono bindings, but
                // I'll use them here for this example
                matrix.SetRow(3, new Vector4(value.x, value.y, value.z));
            }
        }
    }
