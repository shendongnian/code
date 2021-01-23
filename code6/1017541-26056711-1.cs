    bool success = false;
    foreach (var line in allLines)
    {
        var username = line.Split(',')[0];
        var password = line.Split(',')[1];
        if (username == this.UserNameTextBox.Text && password == this.PasswordTextBox.Text)
        {
            // Login
            // this.ViewState["loggedInUser"] = user.Username;
            success = true;
            break;
        }
    }
    if (success == false)
    {
        // Show error
        throw new Exception("Couldn't login, invalid username or password.");
    }
