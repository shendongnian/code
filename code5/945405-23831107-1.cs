    class Z
    {
        public int A { get; private set; }
        public int B { get {return a*a;} }
        public int C { get {return b*a;} } 
        public Z(int a)
        {      
            A = a; // Must always be explicitly defined.
        }
    }
