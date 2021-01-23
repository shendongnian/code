    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace ConsoleApp1
    {
        public static class ListAndArrayExt
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            private static extern int StrCmpLogicalW(string lhs, string rhs);
            public static void SortNatural(this List<string> self)
            {
                self.Sort(StrCmpLogicalW);
            }
            public static void SortNatural(this string[] self)
            {
                Array.Sort(self, StrCmpLogicalW);
            }
        }
        class Program
        {
            void run()
            {
                var strings = new List<string>
                {
                    "1-A",
                    "1-B",
                    "10-A",
                    "10-B",
                    "9-A",
                    "9-B"
                };
                strings.SortNatural();
                foreach (var s in strings)
                    Console.WriteLine(s);
            }
            static void Main()
            {
                new Program().run();
            }
        }
    }
