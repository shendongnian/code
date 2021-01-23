       public abstract class Foo
        {
            static Foo()
            {
                Console.Write("4");
                j = 5;
            }
            protected static int j;
            public static void DoNothing()
            {
            }
        }
        public class Bar : Foo
        {
            static Bar()
            {
                Console.Write("2");
            }
            public static void DoSomething()
            {
                Console.Write(j);
            }
        }
