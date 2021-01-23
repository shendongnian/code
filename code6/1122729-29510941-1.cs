    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication2
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string str = "12386541";
                var chunks = SplitIntoChunks(str, 2, 2, 4);
                Console.WriteLine(string.Join("|", chunks));
            }
            public static IEnumerable<string> SplitIntoChunks(string s, params int[] lengths)
            {
                int start = 0;
                foreach (var length in lengths)
                {
                    if (start >= s.Length)
                        yield return "";
                    else if ((start + length) >= s.Length)
                        yield return s.Substring(start);
                    else
                        yield return s.Substring(start, length);
                    start += length;
                }
            }
        }
    }
