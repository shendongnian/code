    class Program
    {
        static void Write(int i)
        {
            Console.Write(i);
        }
        static void Main(string[] args)
        {
            C c = new C { FunctionToExecute = Write };
            c.SomeMethod(5);
        }
    }
    delegate void D(int F);
    class C
    {
        public D FunctionToExecute { get; set; }
        public void SomeMethod(int arg)
        {
            FunctionToExecute(arg);
        }
    }
