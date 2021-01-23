    protected void Application_OnPostAuthenticateRequest(object sender, EventArgs e)
    {
        if (!Request.Path.Contains("NoAccess"))
        {
            //Checks rights to application
            var secData = SecurityProvider.GetSecurityData("TEST", Request.LogonUserIdentity, false);
            var access = new SecurityClient(secData).HasAccess("TEST", SecurityAccessLevel.Read);
            if (!access)
            {
                Response.Redirect("NoAccess");
            }
        } 
    }
