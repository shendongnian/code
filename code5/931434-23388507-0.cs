    class _3DMatrix
    {
        public int[, ,] m;
    
        public _3DMatrix(int N, int a)
        {
            m = new int[N, N, N];
            Buffer.BlockCopy(Enumerable.Repeat(a, m.Length).ToArray(), 0, m, 0, m.Length * Marshal.SizeOf(a));
        }
    }
