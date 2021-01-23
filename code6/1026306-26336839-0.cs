    public class ListBoxItem<T>
    {
        private Func<T, string> _getText;
        public T Item { get; private set; }
        public ListBoxItem<T>(T item, Func<T, string> getText)
        {
            Item = item;
            _getText = getText;
        }
        public override string ToString()
        {
            return _getText(Item);
        }
    }
