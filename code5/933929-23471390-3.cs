    foreach (UserContainer user in users)
    {
        var txtUsername = new TextBox();
        txtUsername.ID = Guid.NewGuid().ToString("N");
        txtUsername.Text = user.Username; // <- Shows projectname!
        var txtUsername2 = new TextBox();
        txtUsername2.ID = Guid.NewGuid().ToString("N");
        txtUsername2.EnableViewState = false;
        txtUsername2.Text = user.Username; // <- Shows username!
    
        this.UserPanel.Controls.Add(txtUsername);
        this.UserPanel.Controls.Add(txtUsername2);
    }
