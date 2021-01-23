    class Program
    {
        public int i = 10;
    }
    class C : Program
    {
        public int i = 20;
        public void Display()
        {
            C c = new C();
            Console.WriteLine(base.i);//prints 10
            Console.WriteLine(c.i);//prints 20
        }
    }
