    abstract class ListControlItems
    {
        public abstract int Count { get; }
        public abstract int Add(object item);
        public abstract void RemoveAt(int index);
        // etc.
    }
    class ListBoxControlItems : ListControlItems
    {
        private ListBox.ObjectCollection _items;
        public ListBoxControlItems(ListBox.ObjectCollection items)
        {
            _items = items;
        }
 
        public override int Count { get { return _items.Count; } }
        public override int Add(object item) { return _items.Add(item); }
        public override void RemoveAt(int index) { _items.RemoveAt(index); }
        // etc.
    }
