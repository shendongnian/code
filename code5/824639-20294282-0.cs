    public ObservableCollection<string> AllValues { get; set; }
    public ViewModel()
    {
        AllValues = new ObservableCollection<string>(Pairs.Select(x => x.Value));
    }
