        public static void Main()
        {
            var exampleList = new List<int> { 1, 3, 5, 6, 7, 8, 6, 5, 6, 6 };
            var customSelection = new List<int> {1, 5, 6, 6, 8};
            var counts = customSelection.GroupBy(x => x)
                         .ToDictionary(i => i.Key, i => i.Count());
            var removedCounts = new Dictionary<int, int>();
            var result = new List<int>(exampleList);
            result.RemoveAll(x => RemovalCheck(counts, removedCounts, x));
        }
        private static bool RemovalCheck(Dictionary<int, int> counts, Dictionary<int, int> removed, int item)
        {
            if (!counts.ContainsKey(item))
                return false;
            if (!removed.ContainsKey(item))
                removed[item] = 0;
            if (removed[item] >= counts[item])
                return false;
            removed[item]++;
            return true;
        }
