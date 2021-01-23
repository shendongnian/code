        private object selectedItem;
        public MyViewModel()
        {
            this.AvailableItems = new Collection<Type>() { typeof(MyModel1), typeof(MyModel2), typeof(MyModel3) };
            this.Items = new ObservableCollection<object>();
        }
        public Collection<Type> AvailableItems { get; set; }
        public ObservableCollection<object> Items { get; set; }
        public void AddItem(Type type)
        {
            var item = Items.FirstOrDefault(i => i.GetType() == type);
            if (item == null)
            {
                item = Activator.CreateInstance(type);
                Items.Add(item);
            }
            SelectedItem = item;
        }
        internal void RemoveItem(object item)
        {
            var itemIndex = this.Items.IndexOf(item);
            if (itemIndex > 0)
            {
                SelectedItem = Items[itemIndex - 1];
            }
            else if (Items.Count > 1)
            {
                SelectedItem = Items[itemIndex + 1];                
            }
            Items.Remove(item);
        }
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
