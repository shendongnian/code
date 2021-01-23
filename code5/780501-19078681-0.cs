    if (!userNames.Contains(userNameBox.Text.Trim()))
        {                
            MessageBox.Show(
                 "Sorry, that user name is not available, try again",
                 "Invalid Username Entry");
    
            userNameBox.Text = "";
            passwordBox.Text = "";
            repeatPasswordBox.Text = "";
            return false;
        }
        else
            return true;
