        static void Main(string[] args)
        {
            Console.WriteLine("Attach Windbg now");
            Console.ReadLine();
            int size = 20000000;
            var something = new byte[size];
            Console.WriteLine("Look again");
            Console.ReadLine();
    // not sure if its needed but have it so that this object is still referenced and optimizations don't remove it proactively
            something[0] = 1;
        }
