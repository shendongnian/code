    public string Status {
      get { return _status; }
    
      set {
        //if (_status == value)
        //{
        //  return;
        //}
        _status = value;
        // Following line is the key bit. When this(property-changed event) is raised, your animation should start.
        // So whenever you need your animation to run, you need this line to execute either via this property's setter or elsewhere by directly raising it
        RaisePropertyChanged(() => Status);
      }
    }
