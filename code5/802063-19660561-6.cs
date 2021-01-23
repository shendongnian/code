    using System;
    using System.Diagnostics;
    using System.Text;
    static class Program
    {
        static void Main(string[] args)
        {
            for (int length = 50; length <= 51200; length = length * 2)
            {
                string input = new string(' ', length);
                // warm up
                PerformTest(input, 1);
                // actual test
                PerformTest(input, 100000);
            }
        }
        static void PerformTest(string input, int iterations)
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
            int gcRuns = GC.CollectionCount(0);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = iterations; i > 0; i--)
            {
                StringBuilder sb = new StringBuilder(input);
                sb[0] = 'A';
                input = sb.ToString();
            }
            long ticksWithStringBuilder = sw.ElapsedTicks;
            int gcRunsWithStringBuilder = GC.CollectionCount(0) - gcRuns;
            GC.Collect();
            GC.WaitForFullGCComplete();
            gcRuns = GC.CollectionCount(0);
            sw = Stopwatch.StartNew();
            for (int i = iterations; i > 0; i--)
            {
                input = "A" + input.Substring(1);
            }
            long ticksWithConcatSubstring = sw.ElapsedTicks;
            int gcRunsWithConcatSubstring = GC.CollectionCount(0) - gcRuns;
            if (iterations > 1)
            {
                Console.WriteLine(
                    "String length: {0, 5} With StringBuilder {1, 9} ticks {2, 5} GC runs, alternative {3, 9} ticks {4, 5} GC Runs, speed ratio {5:0.00}", 
                    input.Length, 
                    ticksWithStringBuilder, gcRunsWithStringBuilder, 
                    ticksWithConcatSubstring, gcRunsWithConcatSubstring, 
                    ((double)ticksWithStringBuilder) / ((double)ticksWithConcatSubstring));
            }
        }
    }
