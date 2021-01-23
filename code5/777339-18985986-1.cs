    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        {
            Response.Clear();
            Response.Redirect("/login", false);
            Context.ApplicationInstance.CompleteRequest();
        }
        else
        {
            // etc
        }
    }
Context.ApplicationInstance.CompleteRequest();
