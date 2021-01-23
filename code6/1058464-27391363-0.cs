    namespace FirstHalf
    {
        public class Base
        {
            protected static void PrintFoo()
            {
                Console.WriteLine("Foo");
            }
        }
    }
    namespace SecondHalf
    {
        public class Derived : FirstHalf.Base
        {
            public static void Main(string[] args)
            {
                PrintFoo();
            }
        }
    }
