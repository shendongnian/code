    public class BaseHome
    {
        static System.IO.TextWriter Console
        {
            get
            {
                System.Console.Write("B C\rB");
                return System.Console.Out;
            }
        }
        public static void Main()
        {
            Console.WriteLine("A");
            // System.Console.ReadLine();
        }
    }
