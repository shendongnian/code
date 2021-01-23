        public void loginButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LoginUserName.Text))
            {
                ////Password could be empty for some user's
                if (LoginPassword.Password == null)
                    LoginPassword.Password = string.Empty;
                NpgsqlConnection con = new NpgsqlConnection("Server=localhost;Port=1234;UserID=postgres;Password=root;Database=postgres");
                con.Open();
                String username = LoginUserName.Text.Trim();
                String encPassword = TripleDESCrypto.Encrypt(LoginPassword.Password.Trim(), true);
                String query = "SELECT count(*) FROM login where username= '" + username + "' and password = '" + encPassword + "';";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                int? dr = cmd.ExecuteScalar() as int?;
                if (dr.HasValue && dr.Value > 0)
                {
                    // ServiceContainer.GetService<INavigationService>().Navigate("ModuleHomeScreen", null, this);
                    LoginErrorMessage.Text = "Login Successfull";
                    MainWindow appWindow = new MainWindow();
                    ModuleHomeScreen appScreen = new ModuleHomeScreen();
                    appWindow.MainWindowNavigationFrame.Navigate(appScreen, null);
                }
                else
                {
                    LoginErrorMessage.Text = "Invalid Login Credentials.";
                }
            }
            else
            {
                LoginErrorMessage.Text = "Please enter user name !";
            }
        }
