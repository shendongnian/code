    public partial class TestWindow : Window
    {
        public ObservableCollection<ManagementFunctionModel> MyList { get; private set; }
    
        public TestWindow()
        {
            InitializeComponent();
    
            DataContext = this;
            MyList = new ObservableCollection<ManagementFunctionModel>();
            MyList.Add(new ManagementFunctionModel() { RangeLeft = 4 });
        }
    }
