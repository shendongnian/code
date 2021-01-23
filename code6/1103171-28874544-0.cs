    private readonly ObservableCollection<string> myList;
    public ViewModel()
    {
        myList = new ObservableCollection<string>();
    }
    public ObservableCollection<string> MyList
    {
        get { return myList; }
    }
    public void FillData()
    {
        // add any items you like, no need to recreate the list
    }
