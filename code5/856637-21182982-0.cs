    private string newTitle = string.Empty;
    private ObservableCollection<ObservableCollection<string>> collections = new 
        ObservableCollection<ObservableCollection<string>>();
    public ObservableCollection<ObservableCollection<string>> Collections
    {
        get { return collections; }
        set { collections = value; OnPropertyChanged(() => Collections); }
    }
    public string NewTitle
    {
        get { return newTitle; }
        set { newTitle = value; OnPropertyChanged(() => NewTitle); }
    }
    public void AddCollection()
    {
        ObservableCollection<string> collection = new ObservableCollection<string>();
        collection.Add(NewTitle);
        Collections.Add(collection);
    }
