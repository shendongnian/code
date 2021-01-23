    public class MyViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Item> _MyItems;
        public ObservableCollection<Item> MyItems
        {
            get
            {
                return _MyItems;
            }
            set
            {
                if (_MyItems != null)
                {
                    foreach (var item in _MyItems)
                    {
                        item.PropertyChanged -= PropertyChanged;
                    }
                }
                if (value != null)
                {
                    foreach (var item in value)
                    {
                        item.PropertyChanged += PropertyChanged;
                    }
                }
                OnPropertyChanged();
            }
        }
        private Item _SelectedItem;
        public Item SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
