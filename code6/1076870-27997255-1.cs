        public partial class LoginView : UserControl, INotifyPropertyChanged
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = this;
            LoggedIn = true;
            OnLogin(null, null);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public string LoginButtonText
        {
            get { return (string)GetValue(LoginButtonTextProperty); }
            set { SetValue(LoginButtonTextProperty, value); }
        }
        public static readonly DependencyProperty LoginButtonTextProperty =
            DependencyProperty.Register("LoginButtonText", typeof(string), typeof(LoginView));
        public bool LoggedIn
        {
            get { return (bool)GetValue(LoggedInProperty); }
            set { SetValue(LoggedInProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LoggedIn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoggedInProperty =
            DependencyProperty.Register("LoggedIn", typeof(bool), typeof(LoginView), new PropertyMetadata(OnLoggedIn));
        static void OnLoggedIn(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var view = (LoginView)o;
            if (view == null) return;
            view.LoggedIn=(bool)e.NewValue;
            view.LoginButtonText = view.LoggedIn ? "Logoff" : view.LoggingIn ? "Logging In ..." : "Login";
            view.RaisePropertyChanged("LoginButtonText");
            view.RaisePropertyChanged("LoggedIn");
        }
        
        public bool LoggingIn
        {
            get { return (bool)GetValue(LoggingInProperty); }
            set { SetValue(LoggingInProperty, value); }
        }
        public static readonly DependencyProperty LoggingInProperty =
            DependencyProperty.Register("LoggingIn", typeof(bool), typeof(LoginView), new PropertyMetadata(OnLoggingIn));
        static void OnLoggingIn(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var view = (LoginView)o;
            if (view == null) return;
            view.LoggingIn=(bool)e.NewValue;
            view.LoginButtonText = view.LoggedIn ? "Logoff" : view.LoggingIn ? "Logging In ..." : "Login";
            view.RaisePropertyChanged("LoginButtonText");
            view.RaisePropertyChanged("LoggingIn");
        }
        
        void OnLogin(object _, RoutedEventArgs __)
        {
            if (LoggedIn)
            {
                LoggedIn = false;
                LoggingIn = false;
            }
            else
            {
                LoggingIn = true;
                Task.Run(async () =>
                {
                    await Task.Delay(3000); // simulating logon
                    Dispatcher.Invoke(() =>
                    {
                        LoggedIn = true;
                        LoggingIn = false;
                    });
                });
            }
        }
    }
