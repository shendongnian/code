    public class MainVm : DependencyObject
    {
        /// <summary>
        /// Gets or sets a bindable value that indicates Login
        /// </summary>
        public LoginVm Login
        {
            get { return (LoginVm)GetValue(LoginProperty); }
            set { SetValue(LoginProperty, value); }
        }
        public static readonly DependencyProperty LoginProperty =
            DependencyProperty.Register("Login", typeof(LoginVm), typeof(MainVm), 
            new PropertyMetadata(null));
    }
    public class LoginVm : DependencyObject
    {
        /// <summary>
        /// Gets or sets a bindable value that indicates Username
        /// </summary>
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }
        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string), typeof(LoginVm), 
            new PropertyMetadata(""));
    }
