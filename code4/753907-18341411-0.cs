    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            // If the user type doesn't equal user, they're enabled
            btnAdd.Enabled = user.Type != "User";
            btnEdit.Enabled = user.Type != "User";
            btnDelete.Enabled = user.Type != "User";
        }
    }
