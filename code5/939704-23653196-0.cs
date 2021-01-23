    public string Status {
      get { return _status; }
    
      set {
        if (_status == value)
        {
          return;
        }
        _status = value;
        RaisePropertyChanged(() => Status);
      }
    }
