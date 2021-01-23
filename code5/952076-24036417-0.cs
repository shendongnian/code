    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
    
            this.DataContext = new MainViewModel(this);
    
        }
    }
