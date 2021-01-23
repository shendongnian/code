    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ShowLogin()
        {
            var loginview = new LoginView();
            this.Content = loginview;
        }
        private void ShowMenu()
        {
            var menu = new MenuView();
            this.Content = menu;
        }
    }
