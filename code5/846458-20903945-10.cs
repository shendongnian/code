    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ViewModel = new MyViewModel();
            InitializeComponent();
        }
        public MyViewModel ViewModel { get; set; }
    }
