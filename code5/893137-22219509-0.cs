    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace ConsoleApp1
    {
        class Flag
        {
            public volatile bool Value;
        }
        sealed class Program
        {
            private void run()
            {
                flag.Value = true;
                Task.Factory.StartNew(resetFlagAfter1s);
                int x = 0;
                while (flag.Value)
                    ++x;
                Console.WriteLine("Done");
            }
            private void resetFlagAfter1s()
            {
                Thread.Sleep(1000);
                flag = new Flag();
                flag.Value = false;
            }
            private Flag flag = new Flag();
            private static void Main()
            {
                new Program().run();
            }
        }
    }
