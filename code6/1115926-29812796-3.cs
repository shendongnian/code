    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
           //code here for checking login status
           //.........
           if(loginSuccess)
           {
               DialogResult = true;
           }
           else
           {
               DialogResult = false;
           }
           
           Close();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
           DialogResult = false;
           Close();
        }
    }
