    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace ConsoleApp1
    {
        public static class ListExt
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            private static extern int StrCmpLogicalW(string lhs, string rhs);
            // Version for lists of any type.
            public static void SortNatural<T>(this List<T> self, Func<T, string> stringSelector)
            {
                self.Sort((lhs, rhs) => StrCmpLogicalW(stringSelector(lhs), stringSelector(rhs)));
            }
            // Simpler version for List<string>
            public static void SortNatural(this List<string> self)
            {
                self.Sort(StrCmpLogicalW);
            }
        }
        class Program
        {
            void run()
            {
                List<string> strings = new List<string>()
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
