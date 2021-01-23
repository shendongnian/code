    public int SelectedIndex {
      get {
        return _selectedIndex;
      }
    
      set {
        if (_selectedIndex == value) {
          return;
        }
        
        // At this point _selectedIndex is the old selected item's index
        _selectedIndex = value;
        
        // At this point _selectedIndex is the new selected item's index
        RaisePropertyChanged(() => SelectedIndex);
      }
    }
