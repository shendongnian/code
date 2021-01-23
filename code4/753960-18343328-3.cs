    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    class Program
    {
        static void Main()
        {
            var repl = GenerateRandomStrings(4, 500);
            String s;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 100; ++i)
            {
                sb.Append("cat mouse");
            }
            s = sb.ToString();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (string str in repl)
            {
                s = s.Replace("cat", str);
                s = s.Replace(str, "cat");
            }
            sw.Stop(); Trace.WriteLine(sw.ElapsedMilliseconds); sw.Reset(); sw.Start();
            foreach (string str in repl)
            {
                sb.Replace("cat", str);
                sb.Replace(str, "cat");
            }
            sw.Stop(); Trace.WriteLine(sw.ElapsedMilliseconds);
        }
        static HashSet<string> GenerateRandomStrings(int length, int amount)
        {
            HashSet<string> strings = new HashSet<string>();
            while (strings.Count < amount)
                strings.Add(RandomString(length));           
            return strings;
        }
        static Random rnd = new Random();
        static string RandomString(int length)
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < length; ++i)
                b.Append(Convert.ToChar(rnd.Next(97, 122)));
            return b.ToString();
        }
    }
