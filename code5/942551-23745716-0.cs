    private _status _myStatus;
    public _status AuthStatus
    {
      get { return _myStatus; }
      set 
      { 
         _myStatus = value;
         NotifyPropertyChanged("AuthStatus")
      }
    }
