    using System;
    using System.Linq;
    using System.Diagnostics;
    class Program
    {
        static void Main()
        {
            const int Flops = 10000000;
            var random = new Random();
            var output = Enumerable.Range(0, Flops)
                             .Select(i => random.NextDouble())
                             .ToArray();
            var left = Enumerable.Range(0, Flops)
                             .Select(i => random.NextDouble())
                             .ToArray();
            var right = Enumerable.Range(0, Flops)
                             .Select(i => random.NextDouble())
                             .ToArray();
            var timer = Stopwatch.StartNew();
            for (var i = 0; i < Flops - 1; i++)
            {
                unchecked
                {
                    output[i] += left[i] * right[i];
                }
            }
            timer.Stop();
            for (var i = 0; i < Flops - 1; i++)
            {
                output[i] = random.NextDouble();
            }
            timer = Stopwatch.StartNew();
            for (var i = 0; i < Flops - 1; i++)
            {
                unchecked
                {
                    output[i] += left[i] * right[i];
                }
            }
            timer.Stop();
            Console.WriteLine("ms: {0}", timer.ElapsedMilliseconds);
            Console.WriteLine(
                "MFLOPS: {0}",
                (double)Flops / timer.ElapsedMilliseconds / 1000.0);
        }
    }
