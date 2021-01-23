    public partial class MVVMTreeViewSample : Window
    {
        private ObservableCollection<HierarchicalData> Data; 
        public MVVMTreeViewSample()
        {
            InitializeComponent();
            DataContext = Data = CreateData();
        }
        private void Select(IEnumerable<HierarchicalData> items, bool isselected)
        {
            while (items.Any())
            {
                items.ToList().ForEach(x => x.IsSelected = isselected);
                items = items.SelectMany(x => x.Children);
            }  
        }
        private void SelectAll(object sender, RoutedEventArgs e)
        {
            Select(Data, true);
        }
        private void SelectNone(object sender, RoutedEventArgs e)
        {
            Select(Data, false);
        }
        private ObservableCollection<HierarchicalData> CreateData()
        {
            return new ObservableCollection<HierarchicalData>
            {
                //... Dummy Data here
            }
        }
    }
