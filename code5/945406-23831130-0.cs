    class Z
    {
        private int a;
        public int A { get; 
                       private set
                       {
                          a = value;
                          B = //calculation
                          C = //calculation
                       } 
                     }
    
        public int B { get; private set; } 
        public int C { get; private set; } 
    
    
    
        public Z(int a)
        {
            A = a; // Must always be explicitly defined.
        }
    }
