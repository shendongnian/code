    class _3DMatrix
    {
        public static int[, ,] m;
        public _3DMatrix(int a, int n1, int n2, int n3)
        {
            m = new int[n1,n2,n3];
            for (int x = 0; x < n1; x++)
            {
                for (int y = 0; y < n2; y++)
                {
                    for (int z = 0; z < n3; z++)
                    {
                        m[x, y, z] = a;
                    }
                }
            }
        }
