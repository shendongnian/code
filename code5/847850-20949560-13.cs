    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.ViewModel = new MyViewModel2();
            InitializeComponent();
        }
        public MyViewModel ViewModel { get; set; }
    }
