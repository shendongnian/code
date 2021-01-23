    public partial class LoginWindow : Window
    {
        public LoginResult Result { get; private set; }
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            //example login button
            Result = DoLogin();
            Close();
        }
        private LoginResult DoLogin()
        {
            //NOTE: Add your login logic here (for now sucess response)
            return LoginResult.Success;
        }
    }
    public enum LoginResult
    {
        Unknow,
        Success,
        Failed
    }
