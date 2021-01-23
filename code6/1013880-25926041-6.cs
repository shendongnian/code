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
        private Dictionary&lt;Type, Dictionary&lt;int, Item&gt;&gt; items;
        public ItemContainer()
        {
            items = new Dictionary&lt;Type, Dictionary&lt;int, Item&gt;&gt;();
        }
        public T Get&lt;T&gt;(int id) where T: Item
        {
            var t = typeof(T);
            if (!items.ContainsKey(t)) return null;
            if (!items[t].ContainsKey(id)) return null;
            return (T)items[t][id];
        }
        public void Set&lt;T&gt;(T item) where T: Item
        {
            var t = typeof(T);
            if (!items.ContainsKey(t))
            {
                items[t] = new Dictionary&lt;int, Item&gt;();
            }
            items[t][item.Id] = item;
        }
    }
