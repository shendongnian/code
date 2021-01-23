    public class FilteredStringList<T> : ICollection<T>
    {
        private Collection<T> _internalCollection = new Collection<T>();
        public bool Filter { get; set; }
        public void Add(T item)
        {
            if (!Filter || item.StartsWith("A", StringComparison.InvariantCultureIgnoreCase))
                _internalCollection.Add(item);
        }
        public void Clear()
        {
            _internalCollection.Clear();
        }
     
        // TODO implement other pass-through ICollection<T> methods
    }
