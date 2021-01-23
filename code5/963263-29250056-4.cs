    public MainViewModel()
        {
            _tbCtrlItems.Add(new DXTabItem()
            {
                Header = "Test1",
                Content = new Views.View1() {DataContext = new ViewModel1()}
            });
            _tbCtrlItems.Add(new DXTabItem()
            {
                Header = "Test2",
                Content = new Views.View2() { DataContext = new ViewModel2() }
            });
        }
        private ObservableCollection<DXTabItem> _tbCtrlItems = new ObservableCollection<DXTabItem>();
        public ObservableCollection<DXTabItem> TbCtrlItems
        {
            get { return _tbCtrlItems; }
            set { SetProperty(ref _tbCtrlItems, value, () => TbCtrlItems); }
        }
