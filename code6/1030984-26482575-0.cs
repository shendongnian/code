    private bool _isConnected;
    public bool IsConnected
    {
      get { return _isConnected; }
      set
      {
        if (_isConnected != value)
        { 
          _isConnected = value;
          RaisePropertyChanged(); //or something similar
          Command1.RaiseCanExecuteChanged();
        }
      }
    }
