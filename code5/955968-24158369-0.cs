    private void AuthorizeUser()
        {
            User usr = new User();
            usr.LoginName = _userName;
            usr.LoginPassword = _password;
            User user = _accountService.AuthenticationUser(usr, 1);
            if (user != null)
            {
                var app = new MainWindow();
                var context = new MainViewModel();
                app.DataContext = context;
                app.Show();
                Messenger.Default.Send(new NotificationMessage("LoginSuccess"));
            }
        }
