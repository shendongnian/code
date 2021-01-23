    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        sealed class Program
        {
            void run()
            {
                bool flag = getFlag();
                var results = new string[5];
                Action[] actions;
                if (flag)
                {
                    actions = new Action[]
                    {
                        () => results[0] = function("f1"),
                        () => results[1] = function("f2"),
                        () => results[2] = function("f3")
                    };
                }
                else
                {
                    actions = new Action[]
                    {
                        () => results[3] = function("f4"),
                        () => results[4] = function("f5")
                    };
                }
                Parallel.Invoke(actions); // No tasks are run until you call this.
                for (int i = 0; i < results.Length; ++i)
                    Console.WriteLine("Result {0} = {1}", i, results[i]);
            }
            private bool getFlag()
            {
                return true; // Also try with this returning false.
            }
            string function(string param)
            {
                Thread.Sleep(100); // Simulate work.
                return param;
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
