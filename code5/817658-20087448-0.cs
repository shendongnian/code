        private ObservableCollection<Categories> _CategoryList = new ObservableCollection<Categories>();
        private ObservableCollection<Items> _ItemList = new ObservableCollection<Items>();
    
        private Categories _SelectedCategory;
        private Items _SelectedItem;
    
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            _CategoryList.Add(new Categories(1, "Car"));
            _CategoryList.Add(new Categories(2, "Truck"));
            _CategoryList.Add(new Categories(3, "Motorcycle"));
            SelectedCategory = _CategoryList[0];
        }
    
        public ObservableCollection<Categories> CategoryList
        {
            get { return _CategoryList; }
        }
        public ObservableCollection<Items> ItemList
        {
            get { return _ItemList; }
        }
