    using System;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                int a;
                try
                {
                    DoSomething(out a);
                }
                catch {} // Evil empty catch.
                Console.WriteLine(a); // Compile error.
            }
            public void DoSomething(out int x)
            {
                test();
                x = 0;
            }
            private static void test()
            {
                throw new InvalidOperationException("X");
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
    
