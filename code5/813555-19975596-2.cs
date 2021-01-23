    // List of potential Items, used to populate the options for the Subitems combo box
    public ObservableCollection<string> PossibleSubitems { get; set; }
    // Track the selected Item
    private string _currentItem;
    public string CurrentItem
    {
        get { return _currentItem; }
        set
        {
            _currentItem = value;
            // Changing the item changes the possible sub items
            if (value == "Item 1")
            PossibleSubitems = new ObservableCollection<string>() {"A","B"} ;
            else
            PossibleSubitems = new ObservableCollection<string>() { "C", "D" };
            RaisePropertyChanged("CurrentItem");
            RaisePropertyChanged("PossibleSubitems");
        }
    }
