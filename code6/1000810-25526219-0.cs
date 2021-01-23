    private stop _selectedStop;
    
    public Stop SelectedStop
    {
      get
      { 
        return _selectedStop;
      }
      set
      { 
      if (_selectedStop!= value)
         _selectedStop = value;
      OnPropertyChanged("SelectedStop"); //U should implement this method using INotifyPropertyChanged
      }
    }
