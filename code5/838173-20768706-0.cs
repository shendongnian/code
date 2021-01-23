    public Users.CurrentUser GetSetCurrentUser
    {
    	get
    	{
    		if (Session["cUser"] == null) GetSetCurrentUser = new Users.CurrentUser();
    		return (Users.cUser)Session["CurrentUser"];
    	}
    	set { Session.Add("cUser", value); }
    }
