    public WarehouseList : ObservableCollection<WarehouseItems>
    {
        private T currentItem;
        public WarehouseList() { }
        public T CurrentItem { get; set; } // Implement INotifyPropertyChanged here
        public new void Add(T item)
        {
            base.Add(item);
            if (Count == 1) CurrentItem = item;
        }
    }
