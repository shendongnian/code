    foreach (UserContainer user in users)
    {
        var txtUsername = new TextBox();
        txtUsername.EnableViewState = false;
        txtUsername.Text = user.Username; // <- Shows projectname!
        var txtUsername2 = new TextBox();
        txtUsername2.EnableViewState = false;
        txtUsername2.Text = user.Username; // <- Shows username!
    
        this.UserPanel.Controls.Add(txtUsername);
        this.UserPanel.Controls.Add(txtUsername2);
    }
