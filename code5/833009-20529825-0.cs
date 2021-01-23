    if(context.Session["test"] != null)
    {
        // Read value
        string sessionValue = context.Session["test"].ToString();
        // Delete value from session
        context.Session.Remove("test");
    }
