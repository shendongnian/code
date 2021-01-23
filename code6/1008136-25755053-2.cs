    class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new List<int>(Enumerable.Range(0,100));
            int[] values = {5, 12, 25, 17, 0};
            Console.WriteLine("thread: {0}", Environment.CurrentManagedThreadId);
            var result = items.AsParallel().WhereContains(values, x=>x).ToList();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
    static class Extensions
    {
        public static ParallelQuery<TSource> WhereContains<TSource, TKey>(
            this ParallelQuery<TSource> source,
            IEnumerable<TKey> values,
            Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> elements = new HashSet<TKey>(values);
            return source.Where(item =>
            {
                Console.WriteLine("item:{0} thread: {1}", item, Environment.CurrentManagedThreadId);
                return elements.Contains(keySelector(item));
            });
        }
    }
