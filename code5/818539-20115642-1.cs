    class Program
    {
        //public int i = 10; //No field named i
    }
    class C : Program
    {
        public int i = 20;
        public void Display()
        {
            C c = new C();
            Console.WriteLine(base.i);//Compile time error here
            Console.WriteLine(c.i);//this refers to C.i field
        }
    }
