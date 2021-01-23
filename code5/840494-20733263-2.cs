    class Program
    {
 
        static void Main(string[] args)
        {
            Console.WriteLine( p() || q() ); //prints Return True from p , True
            Console.WriteLine( q() || p() ); //prints Return False from q, Return true from p, True
        }
        static bool p()
        {
            Console.WriteLine("Return True");
            return true;
        }
        static bool q()
        {
            Console.WriteLine("Return False");
            return false;
        }
    }
