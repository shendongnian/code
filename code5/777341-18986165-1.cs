    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Clear();
            Response.Redirect("/login", true); // btw true is the default...
        }
        else
        {
            // etc
        }
    }
