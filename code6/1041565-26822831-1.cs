    class Program2
    {
        static void Main(string[] args)
        {
            SearchTime();
        }
        static int Search(Func<bool> func)
        {
            int start = Environment.TickCount;
            func();
            int end = Environment.TickCount;
            return end - start;
        }
        static void SearchTime()
        {
            int ticks1 = Search(ListContains); // Note: do not use () on ListContains
            int ticks2 = Search(DictionaryContainsKey); // Note: do not use () on DictionaryContainsKey
            /* some more code */
        }
        static IList<string> list = new[] { "" };
        static bool ListContains()
        {
            return list.Contains("item");
        }
        static IDictionary<string, string> dictionary = new Dictionary<string, string> {{"key","value"}};
        static bool DictionaryContainsKey()
        {
            return dictionary.ContainsKey("key");
        }
    }
