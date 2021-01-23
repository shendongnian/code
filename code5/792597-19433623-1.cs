    protected void UserLoginOnLoggedIn(object sender, EventArgs e)
    {
        //Since returnUrl must get ItemID and Dept separately, must make sure
        //they are not null, otherwise a dangerous request error may occur
        //Try/catch is also intended to prevent this
        try
        {
        bool itemn = String.IsNullOrEmpty(Request.QueryString["ItemID"]);
        bool deptn = String.IsNullOrEmpty(Request.QueryString["Dept"]);
        string returnUrl = Request.QueryString["ReturnUrl"] + "&ItemID=" +
            Request.QueryString["ItemID"] + "&Dept=" + Request.QueryString["Dept"];
        if (!String.IsNullOrEmpty(returnUrl) && !itemn && !itemn)
            LoginUser.DestinationPageUrl = returnUrl;
        else
            LoginUser.DestinationPageUrl = "~/Default.aspx";
        Response.Redirect(LoginUser.DestinationPageUrl);
        }
        catch
        {
            Response.Redirect("~/Default.aspx");
        }
    }
