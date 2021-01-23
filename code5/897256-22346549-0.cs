    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Security;
    namespace ConsoleApp1
    {
        [SuppressUnmanagedCodeSecurity]
        internal static class NativeMethods
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            public static extern int StrCmpLogicalW(string psz1, string psz2);
        }
        public sealed class NaturalStringComparer: IComparer<string>
        {
            public int Compare(string a, string b)
            {
                return NativeMethods.StrCmpLogicalW(a, b);
            }
        }
        sealed class Program
        {
            void run()
            {
                string[] array =
                {
                    "1.Script_DBScript_03122014",
                    "10.Script_DBScript_03122014",
                    "11.Script_DBScript_03122014",
                    "12.Script_DBScript_03122014",
                    "2.Script_DBScript_03122014",
                    "20.Script_DBScript_03122014",
                    "21.Script_DBScript_03122014",
                    "22.Script_DBScript_03122014"
                };
                Array.Sort(array); // Sorts in the wrong order.
                foreach (var filename in array)
                    Console.WriteLine(filename);
                Console.WriteLine("\n");
                Array.Sort(array, new NaturalStringComparer()); // Sorts correctly.
                foreach (var filename in array)
                    Console.WriteLine(filename);
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
