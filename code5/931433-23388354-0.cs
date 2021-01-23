    class _3DMatrix
    {
        public int[, ,] m;
    
        public _3DMatrix(int size, int[,,] a)
        {
            m = new int[size, size, size];
    
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        m[x, y, z] = a[x,y,z];
                    }
                }
            }
        }
