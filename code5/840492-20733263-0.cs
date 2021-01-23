        class Program
    {
 
        static void Main(string[] args)
        {
            Console.WriteLine( p() || q() );
            Console.WriteLine( q() || p() );
        }
        static bool p()
        {
            Console.WriteLine("RT");
            return true;
        }
        static bool q()
        {
            Console.WriteLine("rf");
            return false;
        }
    }
