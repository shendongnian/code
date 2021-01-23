    class Demo : ProtectedDemo
    {
        static void Main(string[] args)
        {
            //ProtectedDemo p = new ProtectedDemo();
            Demo p = new Demo(); //NOTE HERE
            Console.Write("Enter your Name:");
            p.name = Console.ReadLine(); //Here i am getting the error.
            p.Print();
            Console.ReadLine();
        }
    }
