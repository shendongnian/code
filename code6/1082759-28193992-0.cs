    public ObservableCollection<string> MyItems { get; private set; }
    // elsewhere in the same class...
    MyItems = new ObservableCollection<string>();
    MyItems.Add("first");
    MyItems.Add("second");
    MyItems.Add("etc");
