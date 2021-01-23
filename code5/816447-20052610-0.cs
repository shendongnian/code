       private ObservableCollection<TestItem> _TestItems;
       public ObservableCollection<TestItem> TestItems
       {
	   get { return _TestItems;}
	   set 
           { 
              _TestItems = value;
              OnPropertyChanged("TestItems");
           }
	}
