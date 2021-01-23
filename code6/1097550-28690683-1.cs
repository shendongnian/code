    public class ItemWrapper<T>
    {
        public T Item { get; private set; }
        public string DisplayMember { get; private set };
        public ItemWrapper(T item, Func<T, string> displayFactory)
        {
            if(item == null)
            {
                throw new ArgumentNullException("item");
            }
            if(displayFactory == null)
            {
                throw new ArgumentNullException("displayFactory");
            }
            this.Item = item;
            this.DisplayMember = displayFactory(item);
        }
    }
