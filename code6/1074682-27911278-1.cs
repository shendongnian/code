    List<string> AllowedUsers = new List<string>(){"Larry","Moe","Curly"};
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(!AllowedUsers.Contains(User.Identity.Name))
            {
                SpecialAdminOnlyPanel.Visible=false;
            }
        }
    }
