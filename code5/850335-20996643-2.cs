    public ObservableCollection<PmemCombItem> ItemsCollection
    {
       get 
       {
          if (_itemList == null)
          {
              _itemList = new ObservableCollection<PmemCombItem>();
          }
          return _itemList;
       }
    }
