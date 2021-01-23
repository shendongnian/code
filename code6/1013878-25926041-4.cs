    public class Item
    {
        public int Id { get; set; }
        public Vector2 GeoCoord { get; set; }
        public int OwnerId { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
    }
    public class ItemContainer
    {
        private Dictionary<Type, Dictionary<int, Item>> items;
        public ItemContainer()
        {
            items = new Dictionary<Type, Dictionary<int, Item>>();
        }
        public T Get<T>(int id) where T: Item
        {
            var t = typeof(T);
            if (!items.ContainsKey(t)) return null;
            if (!items[t].ContainsKey(id)) return null;
            return (T)items[t][id];
        }
        public void Set<T>(T item) where T: Item
        {
            var t = typeof(T);
            if (!items.ContainsKey(t))
            {
                items[t] = new Dictionary<int, Item>();
            }
            items[t][item.Id] = item;
        }
    }
