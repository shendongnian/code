    class ClassWithAnArrayAndCount
    {
        private int[] values = new int[10];
        private int   taken  = 0;
    
        public void Add(int value)
        {
            if (taken == 10)
                throw new ArgumentOutOfRangeException(); // sorry, no more space
    
            values[taken++] = value;
        }
    
        public int Taken { get { return taken; } }
    }
