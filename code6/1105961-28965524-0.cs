    private ObservableCollection<int> numbers = new ObservableCollection<int>();
    public ObservableCollection<int> Numbers
    {
        get { return numbers; }
        set { numbers = value; NotifyPropertyChanged("Numbers"); }
    }
...
    Numbers = new YourClassFromOtherProject().GetData();
