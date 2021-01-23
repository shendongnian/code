    public static class EnumerableExtensions
    {
        public static List<Object> Peek(this IEnumerable list, String name)
        {
            return list.PeekInternal(name).OfType<Object>().ToList();
        }
        public static List<String> PropertyNames(this IEnumerable list)
        {
            var items = list.OfType<Object>();
            return items.Any()
                ? items.First().GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Select(p => p.Name).ToList()
                : new List<string>();
        }
        private static IEnumerable PeekInternal(this IEnumerable list, String name)
        {
            return from object item in list let property = item.GetType()
                       .GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public) 
                   where property != null select property.GetValue(item, null);
        }
    }
