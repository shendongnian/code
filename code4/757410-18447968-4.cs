    using System;
    using System.Diagnostics;
    
    static class Program
    {
        static void Main()
        {
            int count = 1;
            
            // First run for JIT warm-up
            IsNullOrEmpty(null, count);
            TestEqualsEmpty(null, count);
            TestLengthZero(null, count);
            
            count = 1000000000;
            
            Console.WriteLine("Case 1: s == \"test\"");
            RunTests("test", count);
            
            Console.WriteLine("Case 2: s == null");
            RunTests(null, count);
            
            Console.WriteLine("Case 3: s == \"\"");
            RunTests("", count);
        }
        
        static void RunTests(string s, int count)
        {
            var ts = IsNullOrEmpty(s, count);
            Console.WriteLine("\tIsNullOrEmpty:         {0}", ts);
            
            ts = TestLengthZero(s, count);
            Console.WriteLine("\tTest if s.Length == 0: {0}", ts);
            
            ts = TestEqualsEmpty(s, count);
            Console.WriteLine("\tTest if s == \"\":       {0}", ts);
        }
    
        static TimeSpan IsNullOrEmpty(string s, int count)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                if (string.IsNullOrEmpty(s))
                {
                }
            }
            sw.Stop();
            return sw.Elapsed;
        }
    
        static TimeSpan TestLengthZero(string s, int count)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                if (s == null || s.Length == 0)
                {
                }
            }
            sw.Stop();
            return sw.Elapsed;
        }
    
        static TimeSpan TestEqualsEmpty(string s, int count)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                if (s == null || s == "")
                {
                }
            }
            sw.Stop();
            return sw.Elapsed;
        }
    }
