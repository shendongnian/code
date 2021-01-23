    public static class Ext
    {
        public static IEnumerable<T> MakeFirst<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            return items.OrderBy(m => predicate(m) ? 0 : 1);
        }
        public static void Test()
        {
            var givenLocale = 1;
            var items = Enumerable.Range(0, 0).Select(m => new { Id = m, Locale = m });
            var sorted = items.MakeFirst(m => m.Locale == givenLocale).ToList();
        }
    }
