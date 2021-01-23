    class B : A
    {
        public B(string msg):base(msg)
        {
            Console.WriteLine("B" + msg);
        }
        public B():base("default message")
        {
            Console.WriteLine("B" + msg);
        }
    }
    class A
    {
        public A(string msg)
        {
            Console.WriteLine("A" + msg);
        }
    }
