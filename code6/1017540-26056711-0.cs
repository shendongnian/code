    //var path = @"C:\Registered.txt";
    var path = "Registered.txt";
    var allLines = System.IO.File.ReadAllLines(path);
    var userInfo = allLines.Select(l => l.Split(',')).Select(s => new
    {
        Username = s[0],
        Password = s[1]
    }).ToList();
    var user = userInfo.FirstOrDefault(ui => ui.Username.ToLowerInvariant() == this.UserNameTextBox.Text.Trim().ToLowerInvarant());
    if (user != null && user.Password == this.PasswordTextBox)
    {
        // Login is okay
        this.ViewState["loggedInUser"] = user.Username;
    }
    else
    {
        // Show error message
        throw new Exception("Couldn't login, invalid username or password.");
    }
