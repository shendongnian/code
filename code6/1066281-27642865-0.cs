    class Program
    {
        static void Main(string[] args)
        {
            Test tester = (Test)5;
            Console.WriteLine(tester);
            Console.ReadLine();
        }
        public enum Test : int
        {
            Test1 = 1,
            Test2 = 5,
            Test4 = 7
        }
    }
