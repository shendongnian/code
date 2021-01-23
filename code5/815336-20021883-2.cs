    class Program
    {
        public static string read = String.Empty; // Static, what does mean that every one can access it without making a instance
        public static string write = String.Empty; // Static, what does mean that every one can access it without making a instance
        static void Main(string[] args)
        {
            Anymethod();
            Console.WriteLine(read + write);
            Console.ReadLine();
        }
        public static void Anymethod()
        {
            Program.read = "Hello "; // Access the public static variable read in the ProgramClass
            Program.write = "World"; // Access the public static variable write in the Program Class
        }
    }
