    struct MyStruct
    {
        private const int MIN_VALUE = 1200;
        private const int MAX_VALUE = 1599;
        private int x;
        public int X 
        {
            get { return x + MIN_VALUE; }
            set
            {
                if(value > MAX_VALUE)
                    x = MAX_VALUE;
                else if(value < MIN_VALUE)
                    x = MIN_VALUE;
                else
                    x = value;
                x -= MIN_VALUE;
            }
        }
    
        // constructor is not really needed anymore, but can still be added
    }
