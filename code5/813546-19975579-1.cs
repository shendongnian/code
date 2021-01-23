    // Track the selected Subitem
    private string _currentSubitem;
    public string CurrentSubitem
    {
      get { return _currentSubitem; }
      set
      {
        if (_currentSubitem != value)
        {
            _currentSubitem = value;
            NotifyPropertyChanged("CurrentSubitem");
        }
      }
    }
