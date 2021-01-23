    class A
    {
        public A(string foo)
        {
            Console.WriteLine(foo);
        }
    }
    class B : A
    {
        // Error: 'A' does not contain a constructor that takes 0 arguments
        public B()
        {
            Console.WriteLine("B");
        }
    }
