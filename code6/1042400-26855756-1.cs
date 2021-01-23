    class Foo
    {
        private int regirsterR0;
        public int RegirsterR0
        {
            get { return regirsterR0; }
            set { regirsterR0 = value; }
        }
    }
    class Goo
    {
        Foo g = new Foo();
        
        void myMethod()
        {
            // Set Property
            g.RegirsterR0 = 10;
            // Get property
            int _myProperty = g.RegirsterR0;
        }
        
    }
