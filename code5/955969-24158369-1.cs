    public LoginUser()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage obj)
        {
            if(obj.Notification == "LoginSuccess")
            {
                var test = Window.GetWindow(this);
                test.Close();
            }
        }
