    userNameEntry.Completed += (object sender, EventArgs e) =>
        { passwordEntry.Focus(); };
    passwordEntry.Completed += (object sender, EventArgs e) =>
        {
            loginButton.Command.Execute(null);
        };
