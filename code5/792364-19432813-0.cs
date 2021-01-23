    private IEnumerable<Model> _itemsControl;
    public IEnumerable<Model> Data
    {
      get
      {
        return _itemsControl;
      }
      set
      {
        _itemsControl = value;
        RaisePropertyChanged("Data");
      }
    }
