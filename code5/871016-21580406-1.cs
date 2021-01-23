    using System;
    using System.Diagnostics;
    namespace Demo
    {
        internal class Program
        {   
            private void run()
            {
                string s = "12345.6789";
                double result;
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 100000000; ++i)
                    double.TryParse(s, out result);
                Console.WriteLine("Took " + sw.Elapsed);
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
