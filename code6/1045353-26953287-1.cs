    internal class ItemCollection : ObservableCollection<Item>
    {
        public ItemCollection()
        {
        }
        public ItemCollection(IEnumerable<Item> items)
        {
            foreach (Item item in items)
            {
                Add(item);
            }
        }
        internal void RaiseCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            OnCollectionChanged(e);
        }
    }
