    private void loadUserGroup()
    {
        CUsers objCUsers = new CUsers();
        ddlUserGroup.Items.Clear();
        // ddlUserGroup.Items.Insert(0, new ListItem("", "0"));
        ddlUserGroup.Items.Insert(0, new ListItem("Admin", "2"));
        string suserid = User.Identity.Name;
        int iUserID = Convert.ToInt32(suserid.ToString());
        // Get user groups using the new property
        var userGroups = objCUsers.UserGroups;
        lblUserGroup.Visible = userGroups.Any();
        ddlUserGroup.Visible = lblUserGroup.Visible;
        ddlUserGroup.Items.Clear();
        foreach(var userGroup in userGroups)
           ddlUserGroup.Items.Add(new ListItem(userGroup.Name, userGroup.Id));
    }
