    namespace ConsoleApplication1
    {    
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();//A's a namespace
                A.A b = new A.A();//A is a namespace this works!
                global::A.A nuts = new A();//what a disaster....
                Console.ReadLine();
            }
        }
    }
    
    namespace A
    {    
        class A
        {
            public void DoWork()
            {
                A a = new A();//A's a class
                //A.A b = new A.A();//A is a type (class) A.A makes no sense to the compiler
                global::A.A nuts = new A();//what a disaster....
            }
    
        }
    }
