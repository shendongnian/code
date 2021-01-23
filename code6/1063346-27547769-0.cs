    private ObservableCollection<YourDataType> collection = new ObservableCollection<YourDataType>();
    public ObservableCollection<YourDataType> Collection
    {
        get { return collection; }
        set { collection = value; NotifyPropertyChanged("Collection"); }
    }
