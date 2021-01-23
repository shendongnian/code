    users.CurrentChanged += new System.EventHandler(UsersCurrentChanged);
    void UsersCurrentChanged(object sender, EventArgs e)
        {
            authLevel = (users.Current as Model.User).RoleID;
        }
