    using System;
    using System.Collections.Generic;
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
        private Dictionary&lt;Type, object&gt; items;
        public ItemContainer()
        {
            items = new Dictionary&lt;Type, object&gt;();
        }
        public T Get&lt;T&gt;(int id) where T: Item
        {
            var t = typeof(T);
            if (!items.ContainsKey(t)) return null;
            var dict = items[t] as Dictionary&lt;int, T&gt;;
            if (!dict.ContainsKey(id)) return null;
            return (T)dict[id];
        }
        public void Set&lt;T&gt;(Item item) where T: Item
        {
            var t = typeof(T);
            if (!items.ContainsKey(t))
            {
                items[t] = new Dictionary&lt;int, T&gt;();
            }
            var dict = items[t] as Dictionary&lt;int, T&gt;;
            dict[item.Id] = (T)item;
        }
        public Dictionary&lt;int, T&gt; GetAll&lt;T&gt;() where T : Item
        {
            var t = typeof(T);
            if (!items.ContainsKey(t)) return null;
            return items[t] as Dictionary&lt;int, T&gt;;
        }
    }
