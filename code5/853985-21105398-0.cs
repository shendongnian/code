    class B
    {
        private readonly bool _z;
        public bool Z { get { return _z; } }
        
        private readonly int _k;
        public int K { get { return _k; } }
        public B(bool z = false)
        {
            _z = z;
        }
        public B(int k = 1)
        {
            _k = k;
        }
    }
