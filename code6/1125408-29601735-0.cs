    public partial class RecComparer : Window
    {
        public BaselineEntity _blEnty{get;set}
        public List<RecComparisionData> _compData {get;set}
    
        public RecComparer(BaselineEntity blEnty)
        {
            InitializeComponent();
            DataContext = this;
            _blEnty = blEnty;
    
            _compData = blEnty.ComparisionData;
    
            // this is a datagrid, whose xaml is cited below
            //ComparisionDataGrid.ItemsSource = _compData;
        }
    }
