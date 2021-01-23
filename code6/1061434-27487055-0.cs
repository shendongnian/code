    public class ItemCollection<T>
    {
        public List<T> Items { get; set; }
        public ItemCollection(List<T> items)
        {
            Items.Clear();
            foreach (T item in items)
            {
              Items.Add(item);
            }
        }
    }
