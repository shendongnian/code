    void Main()
    {
        // Output: Func<T, int>
        "Test".WhatsThis(x => { throw new Exception("Meh"); });
    }
    
    static class Extensions
    {
        public static void WhatsThis<T>(this T dummy, Action<T> action)
        {
           "Action<T>".Dump();
        }
        public static void WhatsThis<T>(this T dummy, Func<T, int> func)
        {
           "Func<T, int>".Dump();
        }
    }
