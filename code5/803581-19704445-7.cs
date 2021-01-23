    public string SelectedItem
    {
        get { return selectedItem; }
        set { selectedItem = value; NotifyPropertyChanged("SelectedItem"); }
    }
