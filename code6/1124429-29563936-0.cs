    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("After pre {0}", PreInc());
            Console.WriteLine();
            Console.WriteLine("After post {0}", PostInc());
            Console.ReadLine();
        }
        public static int PreInc()
        {
            int a = 0;
            do {
                Console.WriteLine("PreIncrement value of a is {0}", ++a);
            } while (a < 10);
            return a;
        }
        public static int PostInc()
        {
            int a = 0;
            do {
                Console.WriteLine("PostIncrement value of a is {0}", a++);
            } while (a < 10);
            return a;
        }
    }
