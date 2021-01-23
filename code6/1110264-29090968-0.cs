    if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
    {
        // This is an unauthorized, authenticated request... 
        Response.Redirect("~/somewhere.aspx");
    }
