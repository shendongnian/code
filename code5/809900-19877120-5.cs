    public string Number
    {
      get { return _number; }
      set
      {
        _number = value;
        NumberDisplayName = NotifyTaskCompletion.Create(GetDisplayNameAsync(value));
        RaisePropertyChanged("Number");
        RaisePropertyChanged("NumberDisplayName");
      }
    }
    public INotifyTaskCompletion<string> NumberDisplayName
    {
      get; private set;
    }
