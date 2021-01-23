    class A
    {
        public A()
        {
            this.Display();
        }
        public virtual void Display()
        {
            Console.Write("A"); //changed to Write
        }
    }
    class B :A
    {
        public override void Display()
        {
            Console.Write("B"); //changed to Write
        }
    }
    static void Main()
    {
        A a = new B();
        a.Display();
    }
