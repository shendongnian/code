    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.ViewModel = new MyViewModel();
            InitializeComponent();
        }
        public MyViewModel ViewModel { get; set; }
    }
