    private string _status;
    public string Status
    {
      get
      {
        return _status;
      }
      set
      {
        _status = value;
        OnPropertyChanged("Status");
      }
    }
