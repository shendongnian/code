        public static bool In<T>(this IEnumerable<T> source, IEnumerable<T> list)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.All(e => list.Contains(e));
        }
        IEnumerable<int> search = new int[] { 0 };
        IEnumerable<int> found = new int[] { 0, 0, 1, 2, 3 };
        IEnumerable<int> notFound = new int[] { 1, 5, 6, 7, 8 };
        Console.WriteLine(search.In(found));//True
        Console.WriteLine(search.In(notFound));//False
