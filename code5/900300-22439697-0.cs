    private ObservableCollection<SensorData> _dataItems;
    public ObservableCollection<SensorData> dataItems
    {
          get { return _dataItems; }
          set
          {
              if(_dataItems != null ) _dataItems.CollectionChanged -= dataItems_CollectionChanged;
              _dataItems = value;
              if(_dataItems != null ) _dataItems.CollectionChanged += dataItems_CollectionChanged;
              // notify of changes
              NotifyPropertyChanged("dataItems");
              NotifyPropertyChanged("lastItem");
          }
     }
