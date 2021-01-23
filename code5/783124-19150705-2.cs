    for (int  i = 0; i < userAray.Length; i++)
    {
        if (userAray[i] == usernameTextBox.Text)
        {
            usernameExists = true;
            break; // stop checking more values
        }
    }
    if (usernameExists)
    {
        welcomeLabel.Text = "Welcome " + usernameTextBox.Text;
    }
    else 
    {
        welcomeLabel.Text = "unknown user";
    }
