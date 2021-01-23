    public partial class MainWindow : Window
    {
        private List<DataStruct> test;
        public MainWindow()
        {
            Test = new List<DataStruct>();
            Test.Add(new DataStruct { Name = "First", Number = "2", Check = true });
            Test.Add(new DataStruct { Name = "Second", Number = "2" });
            Test.Add(new DataStruct { Name = "Third", Number = "2" });
            InitializeComponent();
            this.DataContext = this;
        }
        public List<DataStruct> Test
        {
            get { return test; }
            set { test = value; }
        }
    }
