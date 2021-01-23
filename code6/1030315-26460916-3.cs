    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                var sw = new Stopwatch();
                string text = randomString(8192, 27367);
                string charsToRemove = "SKFPBPENAALDKOWJKFPOSKLW";
                int dummyLength = 0;
                int iters = 10000;
                for (int trial = 0; trial < 8; ++trial)
                {
                    sw.Restart();
                    for (int i = 0; i < iters; ++i)
                        dummyLength += test1(text, charsToRemove).Length;
                    Console.WriteLine("test1() took " + sw.Elapsed);
                    sw.Restart();
                    for (int i = 0; i < iters; ++i)
                        dummyLength += test2(text, charsToRemove).Length;
                
                    Console.WriteLine("test2() took " + sw.Elapsed);
                    sw.Restart();
                    Console.WriteLine();
                }
            }
            private static string randomString(int length, int seed)
            {
                var rng = new Random(seed);
                var sb = new StringBuilder(length);
                for (int i = 0; i < length; ++i)
                    sb.Append((char) rng.Next(65, 65 + 26*2));
                return sb.ToString();
            }
            private static string test1(string text, string charsToRemove)
            {
                HashSet<char> excludeCharacters = new HashSet<char>(charsToRemove);
                StringBuilder sb = new StringBuilder();
                foreach (char ch in text)
                {
                    if (!excludeCharacters.Contains(ch))
                    {
                        sb.Append(ch);
                    }
                }
                return sb.ToString();
            }
            private static string test2(string text, string charsToRemove)
            {
                foreach (char charToRemove in charsToRemove)
                {
                    int index = text.IndexOf(charToRemove);
                    if (index >= 0)
                        text = text.Remove(index, 1);
                }
                return text;
            }
        }
    }
