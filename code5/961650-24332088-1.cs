    using System;
    using System.Diagnostics;
    
    class Program {
        static void Main(string[] args) {
            double d = double.NaN;
            for (int test = 0; test < 10; ++test) {
                var sw1 = Stopwatch.StartNew();
                bool result1 = false;
                for (int ix = 0; ix < 1000 * 1000; ++ix) {
                    result1 |= double.IsNaN(d);
                }
                sw1.Stop();
                var sw2 = Stopwatch.StartNew();
                bool result2 = false;
                for (int ix = 0; ix < 1000 * 1000; ++ix) {
                    result2 |= IsNaN(d);
                }
                sw2.Stop();
                Console.WriteLine("{0} - {1} x {2}%", sw1.Elapsed, sw2.Elapsed, 100 * sw2.ElapsedTicks / sw1.ElapsedTicks, result1, result2);
    
            }
            Console.ReadLine();
        }
        public static bool IsNaN(double d) {
            // Comparisions of a NaN with another number is always false and hence both conditions will be false.
            if (d < 0d || d >= 0d) {
                return false;
            }
            return true;
        }
    }
