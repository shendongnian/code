    class Program
    {
        static void Main(string[] args)
        {
            var letters = new[] {"a", "b", "c", ""};
            var ordered = letters.OrderBy(l => l, new NullOrEmptyStringReducer());
            Console.Read();
        }
    }
    class NullOrEmptyStringReducer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (string.IsNullOrEmpty(x))
                return 1;
            if (string.IsNullOrEmpty(y))
                return -1;
            return string.Compare(x, y);
        }
    }
