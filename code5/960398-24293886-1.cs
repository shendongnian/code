    namespace ConsoleApplication
    {
        class Test
        {
            private static int count = 0;
            public static object TestMethod()
            {
                count++;
                return null;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var test = Test.TestMethod() ?? new object();
            }
        }
    }
