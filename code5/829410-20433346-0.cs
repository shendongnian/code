    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationWindow navWin = new NavigationWindow();
            navWin.Content = new UserControl1();
            navWin.ShowsNavigationUI = false;
            navWin.Show();
        }
    }
