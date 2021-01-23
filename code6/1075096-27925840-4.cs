    public partial class TestWindow : Window
    {
        public ObservableCollection<ManagementFunctionModel> MyList { get; private set; }
    
        public TestWindow()
        {
            InitializeComponent();
    
            MyList = new ObservableCollection<ManagementFunctionModel>();
            MyList.Add(new ManagementFunctionModel() { RangeLeft = 4 });
            DataContext = this;
        }
    }
