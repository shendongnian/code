    using System;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                Task.Factory.StartNew(resetFlagAfter1s);
                int x = 0;
                while (flag)
                    ++x;
                Console.WriteLine("Done");
            }
            private void resetFlagAfter1s()
            {
                Thread.Sleep(1000);
                flag = false;
            }
            private volatile bool flag = true;
            private static void Main()
            {
                new Program().run();
            }
        }
    }
