    class Foo
    {
        public int RegirsterR0 { get; set; }
    }
    class Goo
    {
        Foo g = new Foo() { RegirsterR0 = 10 };
        
        void myMethod()
        {
            Console.WriteLine("My Value is: {0}", g.RegirsterR0);
        }
    }
