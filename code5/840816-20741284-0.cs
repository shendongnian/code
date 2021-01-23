    internal class Program
    {
        public static class DummyClass
        {
            public static string Bar(int b = 10, int a = 12)
            {
                return a.ToString();
            }
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("{0}", DummyClass.Bar(a: 8));
            Console.ReadKey();
        }
    }
