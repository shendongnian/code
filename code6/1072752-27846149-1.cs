    public partial class MainWindow : Window {
        public SomeViewModel SomeViewModel { get; set; }
        public MainWindow() {
            SomeViewModel = new SomeViewModel();
            DataContext = SomeViewModel;
            InitializeComponent();
        }
    }
