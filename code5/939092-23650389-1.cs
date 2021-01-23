    private async void ApplicationBarDone_Click(object sender, EventArgs e)
    {
        bool isValid = checkForValidation();
        if (isValid)
        {
            string url = txtUrl.Text.ToString().TrimStart(' ').TrimEnd(' ');
            string login = txtLogin.Text.ToString().TrimStart(' ').TrimEnd(' ');
            string clientKey = txtSystemKey.Text.ToString().TrimStart(' ').TrimEnd(' ');
            string psw = txtPassword.Text.ToString().TrimStart(' ').TrimEnd(' ');
            RestfulWebServiceUserDAO userDAO = new RestfulWebServiceUserDAO();
            string result = await userDAO.AuthenticateUserAsync(login, psw, clientKey, url);
            // do whatever you need to do after login.
            // just remember that, during the call to userDAO.AuthenticateUserAsync
            // the UI is responsive and the user can click again
        }
    }
