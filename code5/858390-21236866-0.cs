    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                Stopwatch sw = Stopwatch.StartNew();
                bool result = test();
                Console.WriteLine("Returned " + result + " after " + sw.Elapsed);
            }
            private bool test()
            {
                var method1 = Task.Run(new Func<bool>(Method1));
                var method2 = Task.Run(new Func<bool>(Method2));
                return method1.Result || method2.Result;
            }
            public bool Method1()
            {
                Console.WriteLine("Starting Method1()");
                Thread.Sleep(2000);
                Console.WriteLine("Returning from Method1()");
                return true;
            }
            public bool Method2()
            {
                Console.WriteLine("Starting Method2()");
                Thread.Sleep(3000);
                Console.WriteLine("Returning true from Method2()");
                return true;
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
