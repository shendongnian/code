    private ObservableCollection<YourDataType> otherCollection = new ObservableCollection<YourDataType>();
    public ObservableCollection<YourDataType> OtherCollection
    {
        get { return otherCollection; }
        set { otherCollection = value; NotifyPropertyChanged("OtherCollection"); }
    }
