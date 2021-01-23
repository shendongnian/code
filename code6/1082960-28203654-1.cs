    public ObservableCollection<string> Items
    {
        get { return _items; }
        set
        {
            _items = value;
        //    _selectedItem = _items.FirstOrDefault();
            RaisePropertyChanged("Items");
         //   RaisePropertyChanged("SelectedItem");
        }
    }
