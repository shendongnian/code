        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            var localEvent = PropertyChanged;
            if (localEvent != null)
            {
                localEvent.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private readonly IList<BackgroundColorItem> items = new ObservableCollection<BackgroundColorItem>();
        public IList<BackgroundColorItem> Items
        {
            get
            {
                return items;
            }
        }
        private BackgroundColorItem selectedItem;
        public BackgroundColorItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (Object.Equals(selectedItem, value))
                {
                    return;
                }
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }
        public ViewModel()
        {
            // add the basic items to the ItemCollection during load
            Items.Add(new BackgroundColorItem { Title = "Navy", Brush = Brushes.Navy });
            Items.Add(new BackgroundColorItem { Title = "Red", Brush = Brushes.Red });
            Items.Add(new BackgroundColorItem { Title = "Yellow", Brush = Brushes.Yellow });
            Items.Add(new BackgroundColorItem { Title = "Blue", Brush = Brushes.Blue });
            Items.Add(new BackgroundColorItem { Title = "Green", Brush = Brushes.Green });
        }
