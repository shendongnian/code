        public static IEnumerable<int> GetContiguousCounts<T>(this IEnumerable<T> l, IEqualityComparer<T> cmp)
        {
            T last = default(T);
            var count = 0;
            foreach (var e in l)
            {
                if (count > 0 && !cmp.Equals(e, last))
                {
                    yield return count;
                    count = 0;
                }
                count++;
                last = e;
            }
            if (count > 0)
                yield return count;
        }
        public static IEnumerable<int> GetContiguousCounts<T>(this IEnumerable<T> l)
        {
            return GetContiguousCounts(l, EqualityComparer<T>.Default);
        }
        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 2, 3, 3, 3 };
            var b = a.GetContiguousCounts();
            foreach (var x in b)
                Console.WriteLine(x);
        }
