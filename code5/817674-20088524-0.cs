    if (userLoggedIn) {
                 loginButton.Click += new System.EventHandler(logout);
                loginButton.Click -= login;
            } else {
                loginButton.Click += new System.EventHandler(login);
                loginButton.Click -= logout;
            }
