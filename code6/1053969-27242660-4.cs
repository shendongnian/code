    class Demo : ProtectedDemo
    {
        static void Main(string[] args)
        {
            Demo test = new Demo();
            Console.Write("Enter your Name:");
            test.name = Console.ReadLine(); // create an instance of the deriving class, 
                                            // you can only access the name if you're in the current class created
            test.Print();
            Console.ReadLine();
        }
    }
