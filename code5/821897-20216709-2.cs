    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace StringPerf
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "This is a sample string";
                int count = 100000;
                RunPerf("Warmup", 1, () =>
                    {
                        PerfContructor(input);
                        PerfSubstring(input);
                        PerfAppend(input);
                    });
    
                Console.WriteLine();
                Console.WriteLine();
    
                RunPerf("Constructor", count, () => PerfContructor(input));
                Console.WriteLine();
    
                RunPerf("ToString", count, () => PerfToString(input));
                Console.WriteLine();
    
                RunPerf("Substring", count, () => PerfSubstring(input));
                Console.WriteLine();
    
                RunPerf("Append", count, () => PerfAppend(input));
    
                Console.ReadLine();
            }
    
            static void PerfContructor(string input)
            {
                string firstChar = new String(input[0], 1);
            }
    
            static void PerfToString(string input)
            {
                string firstChar = input[0].ToString();
            }
    
            static void PerfSubstring(string input)
            {
                string firstChar = input.Substring(0, 1);
            }
    
            static void PerfAppend(string input)
            {
                String str = "" + input[0];
            }
    
            static void RunPerf(string name, int count, Action action)
            {
                var sw = new System.Diagnostics.Stopwatch();
                Console.WriteLine(string.Format("Starting perf for {0}. {1} times", name, count));
    
                sw.Start();
                for (int i = 0; i < count; i++)
                {
                    action();
                }
                sw.Stop();
                Console.WriteLine(string.Format("{0} completed in {1}", name, sw.Elapsed));
            }
        }
    }
