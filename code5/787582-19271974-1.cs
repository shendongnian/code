    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        class Program
        {
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
            private static extern int StrCmpLogicalW(string lhs, string rhs);
            
            private void run()
            {
                var list = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("1", "Day 1"), 
                    new KeyValuePair<string, string>("2", "Day 11"), 
                    new KeyValuePair<string, string>("4", "Day 5"),
                    new KeyValuePair<string, string>("6", "Day 13")
                };
                list.Sort((lhs, rhs) => StrCmpLogicalW(lhs.Value, rhs.Value));
                foreach (var keyValuePair in list)
                    Console.WriteLine(keyValuePair);
            }
            static void Main(string[] args)
            {
                new Program().run();
            }
        }
    }
