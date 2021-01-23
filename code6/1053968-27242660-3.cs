        class ProtectedDemo
        {
            protected string name;
            public void Print()
            {
                Console.WriteLine("Name is: {0}", name);
            }
            public void SetName(string newName)
            {
                name = newName;
            }
        }
        static void Main(string[] args)
        {
            ProtectedDemo p = new ProtectedDemo();
            Console.Write("Enter your Name:");
            p.SetName(Console.ReadLine()); 
            p.Print();
            Console.ReadLine();
        }
