    public SomeViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ObservableCollection<string> _itemsList;
        private object _selectedItem;
        public ObservableCollection<object> ItemsList
        {
            get { return _itemsList; }
            set
            {
                if (Equals(value, _itemsList)) return;
                _itemsList = value;
                raisePropertyChanged("ItemsList");
            }
        }
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                raisePropertyChanged("SelectedItem");
            }
        }
    }
