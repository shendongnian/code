    public partial class MainWindow : Window
    {
        private ObservableCollection<TestItem> testItems = new ObservableCollection<TestItem>();
        public ObservableCollection<TestItem> TestItems { get { return  testItems ; }
           
        public MainWindow()
        {
            InitializeComponent();   
            this.DataContext = this;    
            TestItem test = new TestItem("name", "type");    
            this.testItems.Add(test);
        }
    }
