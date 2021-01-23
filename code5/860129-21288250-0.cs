    public ObservableCollection<string> Items
    {
        get { return items; }
        set { items = value; NotifyPropertyChanged("Items"); } }
    }
