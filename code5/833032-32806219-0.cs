    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Char>() { 'A', 'B', 'C', 'D', 'E' };
            int i = 0;
            foreach (var partition in items.Partitions())
            {
                Console.WriteLine(++i);
                foreach (var group in partition)
                {
                    Console.WriteLine(string.Join(",", group));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }  
    public static class Partition
    {
        public static IEnumerable<IList<IList<T>>> Partitions<T>(this IList<T> items)
        {
            if (items.Count() == 0)
                yield break;
            var currentPartition = new int[items.Count()];
            do
            {
                var groups = new List<T>[currentPartition.Max() + 1];
                for (int i = 0; i < currentPartition.Length; ++i)
                {
                    int groupIndex = currentPartition[i];
                    if (groups[groupIndex] == null)
                        groups[groupIndex] = new List<T>();
                    groups[groupIndex].Add(items[i]);
                }
                yield return groups;
            } while (NextPartition(currentPartition));
        }
        private static bool NextPartition(int[] currentPartition)
        {
            int index = currentPartition.Length - 1;
            while (index >= 0)
            {
                ++currentPartition[index];
                if (Valid(currentPartition))
                    return true;
                currentPartition[index--] = 0;
            }
            return false;
        }
        private static bool Valid(int[] currentPartition)
        {
            var uniqueSymbolsSeen = new HashSet<int>();
            foreach (var item in currentPartition)
            {
                uniqueSymbolsSeen.Add(item);
                if (uniqueSymbolsSeen.Count <= item)
                    return false;
            }
            return true;
        }
    }
