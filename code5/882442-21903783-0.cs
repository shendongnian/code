    private void loadUserGroup()
    {
        CUsers objCUsers=new CUsers();
        ddlUserGroup.Items.Clear();
        //ddlUserGroup.Items.Insert(0, new ListItem("", "0"));
        ddlUserGroup.Items.Insert(0, new ListItem("Admin", "2"));
        string suseid= User.Identity.Name;
        int iUserID = Convert.ToInt32(suseid.ToString());
   
