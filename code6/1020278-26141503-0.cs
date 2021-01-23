    public ObservableCollection<Fields> Items 
    { 
        get { return items; } 
        set
        {
            if (items != value)
            {
                items = value;
                OnPropertyChanged("Items");
            }
        } 
    }
    private ObservableCollection<Fields> items;
