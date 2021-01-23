    class X
    {
        private readonly string _a;
        public X()
        {
             _a = "foo";
        }
        
        protected X(string a)
        {
            _a = a;
        }
        public string A { get { return _a; } }
    }
    class Y
    {
        public Y() : base("bar")
        {
        }    
    }
