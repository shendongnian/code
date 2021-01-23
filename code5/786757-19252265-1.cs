    private ObservableCollection<string> items = new ObservableCollection<string>();
    ...
    public ObservableCollection<string> Items
    {
        get { return items; }
        set
        {
            items= value;
            NotifyPropertyChange("Items"); // << Implement INotifyPropertyChanged
        }
    }
