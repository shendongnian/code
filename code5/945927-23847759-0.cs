    private SearchResult _myBindableProperty;
    public SearchResult MyBindableProperty
    {
       get { return _myBindableProperty; }
       set
          {
             if(_myBindableProperty == value)
             return;
             _myBindableProperty = value;
             RaisePropertyChanged("MyBindableProperty");
          }
    }
