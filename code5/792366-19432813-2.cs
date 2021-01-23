    private MobileServiceCollection<ModelAzure, ModelAzure> _itemsControl;
    public MobileServiceCollection<ModelAzure, ModelAzure> Data
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
