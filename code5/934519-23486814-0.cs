    void Main()
    {
        // Output: Func<T, int>
        "Test".WhatThis(x => { throw new Exception("Meh"); });
    }
    
    static class Extensions
    {
        public static void WhatThis<T>(this T dummy, Action<T> action)
        {
           "Action<T>".Dump();
        }
        public static void WhatThis<T>(this T dummy, Func<T, int> func)
        {
           "Func<T, int>".Dump();
        }
    }
