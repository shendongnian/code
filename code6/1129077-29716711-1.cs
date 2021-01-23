    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                xn();
            }
            static void xn()
            {
                double r = 3.9;
                List<double> xr_arr = new List<double>();
                for (double x = 0; x <= 1; x += 0.01)
                {
                    double xr = r * x * (1 - x);
                    xr_arr.Add(xr);
                }
                Console.WriteLine(string.Join(",", xr_arr.Take(24).Select(a => a.ToString()).ToArray()));
            }
        }
    }
