    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void headerLogoutTime_Click(object sender, RoutedEventArgs e)
        {
            SetMenuItemHeader(sender as MenuItem);
        }
        private void headerMin_MouseEnter(object sender, MouseEventArgs e)
        {
            SetMenuItemHeader(sender as MenuItem);
        }
        private void SetMenuItemHeader(MenuItem menuItem) 
        {
            var sb = new StringBuilder();
            if (menuItem != null)
            {
                headerLogoutTime.Header = "";
                headerLogoutTime.Header = sb.Append("LogOut Time: ").Append(headerLogoutTime.Header).Append(menuItem.Header);
            }
        }
    }
