    private string _currentItem;
    public string CurrentItem
    {
      get { return _currentItem; }
      set
      {
        _currentItem = value;
        // Changing the item changes the possible sub items
        NotifyPropertyChanged("PossibleSubitems");
      }
    }
