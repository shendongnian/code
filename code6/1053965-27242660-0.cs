        class ProtectedDemo
        {
            protected string name;
            public void Print()
            {
                Console.WriteLine("Name is: {0}", name);
            }
            public SetName(string newName)
            {
                name = newName;
            }
        }
        static void Main(string[] args)
        {
            ProtectedDemo p = new ProtectedDemo();
            Console.Write("Enter your Name:");
            p.SetName(Console.ReadLine()); //Here i am getting the error.
            p.Print();
            Console.ReadLine();
        }
