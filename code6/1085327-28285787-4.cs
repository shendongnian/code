    protected void Session_Start(object sender, EventArgs e)
    {
       //declare and Initialize your LogIn Session variable
       HttpContext.Current.Session["username"] = string.Empty;
    }
