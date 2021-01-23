    public partial class Sync : Window
    {
        public Sync()
        {
            InitializeComponent();
    
            var viewModel = new SyncViewModel();
            DataContext = viewModel;
        }
    }
