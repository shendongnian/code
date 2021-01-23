    public ObservableCollection<UserInfo> ListDS
    {
        get { return listDS; }
        set
        {
            listDS = value;
            // Call OnPropertyChanged whenever the property is updated
            OnPropertyChanged("ListDS");
        }
    }
    // Create the OnPropertyChanged method to raise the event 
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
