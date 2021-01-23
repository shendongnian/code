    public class FilteredStringList<T> : ICollection<T>
    {
        private Collection<T> _internalCollection = new Collection<T>();
        public bool IsFilterActive { get; set; }
        public Predicate<T> Filter { get; set; }
        public void Add(T item)
        {
            _internalCollection.Add(item);
        }
        public void Clear()
        {
            _internalCollection.Clear();
        }
     
        public int Count
        {
            get { return _internalCollection.Where(item => !IsFilterActive || Filter(item)).Count(); }
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _internalCollection)
            {
                if (!IsFilterActive || Filter(item))
                    yield return item;
            }
        }
        // TODO implement other pass-through ICollection<T> methods
    }
