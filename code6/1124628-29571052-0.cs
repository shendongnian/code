    class Program
    {
        static void Main(string[] args)
        {
            Test(1);
        }
        private static void Test(int i)
        {
            Console.WriteLine(i);
            Test(i + 1);
        }
    }
