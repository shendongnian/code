    public partial class MainWindow : Window
    {
        MainViewModel viewmodel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewmodel;
        }
    }
