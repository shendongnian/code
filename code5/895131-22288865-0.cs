    public static class MyExtensions
    {
        public static Dictionary<int, TSource> ToDictionary<TSource>(
            this IEnumerable<TSource> source)
        {
            var dictionary = new Dictionary<int, TSource>();
            var i = 0;
            foreach(var item in source)
            {
                dictionary.Add(++i, item);
            }
            return dictionary;
        }
    }
