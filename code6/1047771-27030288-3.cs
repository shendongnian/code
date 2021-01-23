    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated) { // if the user is already logged in
            MembershipUser currentUser = Membership.GetUser();
            currentUser.SetSessionVariables();
        }
        else
        {
            Session["CurrentUserID"] = "";
            Session["CurrentUserName"] = "";
        }
    }
