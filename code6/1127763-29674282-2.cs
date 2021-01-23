    public partial class MainWindow : Window
    {
        private IEnumerable<SomeClass> datasource;
        public MainWindow()
        {
            InitializeComponent();
            datasource = new[]
            {
                new SomeClass{FirstValue = "some", SecondValue = "another"},
                new SomeClass{FirstValue = "more",SecondValue = "yet another"}
            };
            this.DataContext = datasource;
        }
    }
