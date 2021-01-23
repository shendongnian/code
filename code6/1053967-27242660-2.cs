    class Demo : ProtectedDemo
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your Name:");
            base.name = Console.ReadLine(); // use it in the current instance 
                                            // since it's of type ProtectedDemo
            base.Print();
            Console.ReadLine();
        }
    }
