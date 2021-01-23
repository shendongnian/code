     private ObservableCollection<NodeBool> _MyData=new ObservableCollection<NodeBool>();
        public ObservableCollection<NodeBool> MyData
        {
            get { return _MyData; }
            set { _MyData = value; RaisePropertyChanged("MyData"); }
        }
