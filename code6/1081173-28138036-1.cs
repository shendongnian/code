    class MainViewModel : Common.UserInterface.ViewModelBase, IDisposable
    {
        public MainViewModel()
    	{
    		CheckAllCommand = new DelegateCommand<bool>(OnCheckAllExecuted);
    	}
    
    	void OnCheckAllExecuted(bool status)
        {
    		// Your logic goes here (if any)	
            CheckAll = items.All(item => item.IsChecked);
        }
    
        public DelegateCommand<ItemViewModel> ItemCommand { get; private set; }
     
        private bool checkAll;
        private ObservableCollection<ItemViewModel> items;
      
        public DelegateCommand<bool> CheckAllCommand
        {
             get;
             private set;
        }
    
        public ObservableCollection<ItemViewModel> Items
        {
             get
             {
                 return items;
             }
             set
             {
                 items = value;
                 OnPropertyChanged(() => Items); 
             }
         }
    
    
         public bool CheckAll
         {
             get { return checkAll; }
             set
             {
                 checkAll = value;
                 OnPropertyChanged(() => CheckAll);
             }
         }
    }
    
    class ItemViewModel : ViewModelBase 
    {   
         public bool ischecked;
         public string data;
    
         public new bool IsChecked
         {
             get { return isChecked; }
             set
             {
                 isChecked = value;
                 OnPropertyChanged("IsChecked");
             }
         }
    
         public string Data
         {
             get { return data; }
             set
             {
                 data = value;
                 OnPropertyChanged("Data");
             }
         }
    }
