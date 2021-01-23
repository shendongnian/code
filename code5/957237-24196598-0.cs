     private ObservableCollection<int> _list = new ObservableCollection<int>();
     public ObservableCollection<int> List
        {
            get { return _list ; }
            set { _list = value; RaisePropertyChanged("List"); }
        } 
