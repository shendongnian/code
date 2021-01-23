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
                string[] filenames =
                {
                    "0.jpeg",
                    "1.jpeg",
                    "10.jpeg",
                    "11.jpeg",
                    "2.jpeg",
                    "20.jpeg",
                    "21.jpeg"
                };
                Array.Sort(filenames); // Sorts in the wrong order.
                foreach (var filename in filenames)
                    Console.WriteLine(filename);
                Console.WriteLine("\n");
                Array.Sort(filenames, new NaturalStringComparer()); // Sorts correctly.
                foreach (var filename in filenames)
                    Console.WriteLine(filename);
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
