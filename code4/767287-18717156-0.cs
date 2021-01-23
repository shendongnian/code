    class Program
    {
        static void Main(string[] args)
        {
            var item1 = new Item()
            {
                Id = 1,
                Items = new List<Item>()
                {
                    new Item()
                    {
                        Id = 2,
                        Items = new List<Item>()
                        {
                            new Item()
                            {
                                Id = 4,
                                Items = new List<Item>()
                            }
                        }
                    },
                    new Item()
                    {
                        Id = 3,
                        Items = new List<Item>()
                    }
                }
            };
            var path = GetPath(item1, (i) => i.Id == 3);
            foreach (var item in path)
            {
                Console.WriteLine(item.Id);
            }
            Console.ReadLine();
        }
        private static IEnumerable<Item> GetPath(Item item, Func<Item, bool> predicate)
        {
            return GetPathRecursive(item, predicate, new List<Item>());
        }
        private static IEnumerable<Item> GetPathRecursive(Item item, Func<Item, bool> predicate, IEnumerable<Item> items)
        {
            var resultCandidate = items.Concat(new List<Item> { item });
            if (predicate(item))
            {
                return resultCandidate;
            }
            else
            {
                if (item.Items == null || item.Items.Count == 0)
                {
                    return new List<Item>();
                }
                foreach (var nextItem in item.Items)
                {
                    var newResult = GetPathRecursive(nextItem, predicate, resultCandidate);
                    if (newResult != null && newResult.Any())
                    {
                        return newResult;
                    }
                }
                return new List<Item>();
            }
        }
    }
    //Item1
    //Item2
    //    Item4
    //Item3
    public class Item
    {
        public int Id { get; set; }
        public IList<Item> Items { get; set; }
    }
