    public ObservableCollection<Item> Items
    {
        get { return items; }
        set
        {
            items = value;
            NotifyPropertyChanged("Items");
        }
    }
