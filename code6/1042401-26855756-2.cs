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
        Foo g = new Foo() { RegirsterR0 = 10 };
        
        void myMethod()
        {
            Console.WriteLine("My Value is: {0}", g.RegirsterR0);
        }
    }
