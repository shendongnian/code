    Public class InventoryItemViewModel: INotifyPropertyChanged
    {  
        public InventoryItemsViewModel()
        {
             PopulateInventoryItems();
        }
        public List<InventoryItem> _inventoryItems;
        
        private List<InventoryItem>
        { 
             get
             {
                return _inventoryItems;
             }
             set
             {
                _inventoryItems = value;
                 RaiseProperyChanged();
             }
        }
      
        //Populate your List here
        Private PopulateInventoryItems()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string PropertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
