    public void SetUser(User user)
    {
	    Session.Add("User", user);
    }
    public User GetUser()
    {
	     User user = (User)Session["User"];
	
	     return user;
    }
