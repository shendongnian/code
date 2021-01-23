    struct MyStruct
    {
        private const int MIN_VALUE = 1200;
        private const int  MAX_VALUE = 1599;
        private int _X;
        public int X
        {
            get { return _X; }
            set { _X = checkBoundaries(value); }
        }
        private static int checkBoundaries(int x)
        {
            if (x > MAX_VALUE)
                return MAX_VALUE;
            else if (x < MIN_VALUE)
                return MIN_VALUE;
            else
                return x;
        }
        public MyStruct(int x)
        {
            _X = checkBoundaries(x);
        }
    }
