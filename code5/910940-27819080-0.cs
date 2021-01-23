    private ObservableCollection<Item> items = new ObservableCollection<Item>();
    public ObservableCollection<Item> Items 
    { 
         get { return items; } 
         set { items = value; RaisePropertyChanged(() => Items); } 
    }
