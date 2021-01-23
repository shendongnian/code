	public void Global_BeginRequest(object sender, EventArgs e)
	{
		if(
			Context.User != null && 
			!String.IsNullOrWhiteSpace(Context.User.Identity.Name) && 
			Context.Session != null && 
			Context.Session["IAMTRACKED"] == null
		)
		{
			Context.Session["IAMTRACKED"] = new object();
			Application.Lock();
			Application["UsersLoggedIn"] = Application["UsersLoggedIn"] + 1;
			Application.UnLock();
		}
	}
