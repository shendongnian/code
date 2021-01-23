    public class ObservableItemCollection<T> : ObservableCollection<T>
    {
        private string propertyName;
        public ObservableItemCollection(string propertyName, int numberOfDefaultItemsToAdd = 0)
            : base()
        {
            this.propertyName = propertyName;
            this.AddDefaults(numberOfDefaultItemsToAdd);
        }
        public ObservableItemCollection(IEnumerable<T> collection, string propertyName, int numberOfDefaultItemsToAdd = 0)
            : base(collection)
        {
            this.propertyName = propertyName;
            this.AddDefaults(numberOfDefaultItemsToAdd);
        }
        public ObservableItemCollection(List<T> list, string propertyName, int numberOfDefaultItemsToAdd = 0)
            : base(list)
        {
            this.propertyName = propertyName;
            this.AddDefaults(numberOfDefaultItemsToAdd);
        }
        public new T this[int index]
        {
            get { return base[index]; }
            set
            {
                base[index] = value;
                // Call ObservableCollection OnPropertyChanged method.
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
        public void AddDefaults(int numberOfDefaultItemsToAdd = 1)
        {
            if (numberOfDefaultItemsToAdd < 0) throw new ArgumentOutOfRangeException("numberOfItemsToAdd must be a non-negative number");
            for(int i = 0; i < numberOfDefaultItemsToAdd; ++i)
                base.Add(default(T));
        }
    }
