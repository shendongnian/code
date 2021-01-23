    public ViewModel()
    {
        Items = new ObservableCollection<object> { 1, 2, 3, 4, 5, 6};
    }
    public ObservableCollection<object> Items { get; set; }
