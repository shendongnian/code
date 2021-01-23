    public bool checkPasswordsValid()
    {
        if (passwordBox.Text == "")
        {
            
            MessageBox.Show("Password fields cannot be empty","Password Error");
            return false;
        }
        return true;
    }
    public bool checkUsernameValid()
    {
        if (userNameBox.Text.Contains("Username: " + userNameBox.Text))
        {
            MessageBox.Show(
                "Sorry, that user name is not available, try again",
                "Invalid Username Entry");
            userNameBox.Text = "";
            passwordBox.Text = "";
            repeatPasswordBox.Text = "";
            return false;
        }
         
        return true;
    }
