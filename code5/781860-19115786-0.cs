    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            private void run()
            {
                // Using tasks directly:
                var task1 = Task<int>.Factory.StartNew(methodOne);
                var task2 = Task<string>.Factory.StartNew(methodTwo);
                var task3 = Task<double>.Factory.StartNew(methodThree);
                // Alternatively:
                // var task1 = Task.Run(new Func<int>(methodOne));
                // var task2 = Task.Run(new Func<string>(methodTwo));
                // var task3 = Task.Run(new Func<double>(methodThree)); 
                string result = string.Format
                (
                    "Task 1: {0}, Task 2: {1}, Task 3: {2}",
                    task1.Result, // Accessing Task.Result automatically
                    task2.Result, // waits for the task to complete.
                    task3.Result 
                );
                Console.WriteLine(result);
                // Using tasks indirectly via Parallel.Invoke():
                int    r1 = 0;
                string r2 = null;
                double r3 = 0;
                Parallel.Invoke
                (
                    () => r1 = methodOne(),
                    () => r2 = methodTwo(),
                    () => r3 = methodThree()
                );
                result = string.Format
                (
                    "Task 1: {0}, Task 2: {1}, Task 3: {2}",
                    r1,
                    r2,
                    r3
                );
                Console.WriteLine(result);
            }
            static int methodOne()
            {
                Thread.Sleep(1000);
                return 1;
            }
            static string methodTwo()
            {
                Thread.Sleep(750);
                return "two";
            }
            static double methodThree()
            {
                Thread.Sleep(500);
                return 3.0;
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
