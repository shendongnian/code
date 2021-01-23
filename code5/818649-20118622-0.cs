    using System;
    namespace Demo
    {
        internal class Program
        {
            private void run()
            {
                Func<double, double> f1 = Math.Sin;
                Func<double, double> f2 = Math.Cos;
                double r1 = runFunc(f1, 1.0);
                double r2 = runFunc(f2, 2.0);
                Console.WriteLine(r1);
                Console.WriteLine(r2);
            }
            private static double runFunc(Func<double, double> func, double parameter)
            {
                return func(parameter);
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
