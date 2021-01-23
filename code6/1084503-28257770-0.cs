    bool userLoggedIn = false;
    if (Session["User"] != null) //check the session variable is actually valid
    {
        if (!String.IsNullOrEmpty(Session["User"]))
        {
            userLoggedIn = true;
        }
    }
    if (!userLoggedIn)
    {
        Response.Redirect("login.aspx");
    }
 
