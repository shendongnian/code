    using System;
    
    class Program
    {
        public static string operator/ (Program lhs, int rhs)
        {
            return "I'm divided!";
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(new Program() / 10);
        }
    }
