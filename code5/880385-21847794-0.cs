    class KeyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var xSplit = x.Split('_').Select(i => Convert.ToInt32(i)).ToArray();
            var ySplit = y.Split('_').Select(i => Convert.ToInt32(i)).ToArray();
            var diff1 = xSplit[0] - ySplit[0];
            return diff1 != 0 ? diff1 : xSplit[1] - ySplit[1];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var comparer = new KeyComparer();
            var sortedDic = new SortedDictionary<string, object>(comparer)
            {
                {"7020_23", new object()},
                {"7030_1", new object()},
                {"7030_5", new object()},
                {"7020_8", new object()},
                {"7020_1", new object()}
            };
            foreach (var key in sortedDic.Keys)
            {
                Console.WriteLine(key);
            }
        }
    }
