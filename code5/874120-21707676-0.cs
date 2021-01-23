    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel mvm = new MainViewModel();
            mvm.Register();
            
           this.DataContext = mvm; //this you need
        }
    }
