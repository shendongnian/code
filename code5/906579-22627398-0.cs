    private ObservableCollection<CollectionType> _ItemSource;
    public ObservableCollection<CollectionType> ItemSource
    {
      get
      {
           return _ItemSource;
      }
      set
      {
        if(_ItemSource!=value)
         {
            _ItemSource=value;
          OnPropertyChanged("ItemSource");
         }
      }
    }
