    class Program
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
            IList<string> list = new []{"item"};
            IDictionary<string, string> dictionary = new Dictionary<string, string> { { "key", "value" } };
            int ticks1 = Search(() => list.Contains("item")); // Note: use () =>
            int ticks2 = Search(() => dictionary.ContainsKey("key")); // Note: use () =>
            /* some more code */
        }
    }
