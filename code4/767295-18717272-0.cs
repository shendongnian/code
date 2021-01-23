    public static class StaticItem
    {
        public static IEnumerable<T> Path<T>(
            this IEnumerable<T> source,
            Func<T, IEnumerable<T>> childrenSelector,
            Predicate<T> condition)
        {
            // no data, no processing
            if (source == null || !source.Any()) return null;
            // if condition matches, return list containing element
            var attempt = source.FirstOrDefault(t => condition(t));
            if (!Equals(attempt, default(T))) return new List<T> { attempt };
            // iterate current items (btw: already done by FirstOrDefault)
            foreach (var item in source)
            {
                // select children
                IEnumerable<T> childs = childrenSelector(item);
                var x = childs.Path(childrenSelector, condition);
                
                // if element was found in path, the result is not null
                if (x != null)
                {
                    // adding item to list
                    var list = new List<T>();
                    list.Add(item);
                    list.AddRange(x);
                    return list;
                }
            }
            return null;
        }
    }
        static void Main()
        {
            Item item1 = new Item { Id = 1 };
            Item item2 = new Item { Id = 2 };
            Item item3 = new Item { Id = 3 };
            Item item4 = new Item { Id = 4 };
            item1.Items = new List<Item> { item2, item3 };
            item2.Items = new List<Item> { item4 };
            List<Item> all = new List<Item> { item1 };
            var x = all.Path( item => item.Items, i => i.Id == 4);
        }
