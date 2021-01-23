    protected void Save(Query query, string queryTitle)
    {
        // would probably be better to refactor this bit out into its own method
        string sCookieHeader = Request.Headers["Cookie"];
        if (Context.Session != null 
            && Context.Session.IsNewSession
            && sCookieHeader != null
            && sCookieHeader.IndexOf("ASP.NET_SessionId") >= 0)
        {
            // session has expired
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            Response.StatusCode = 401
        }
        else
        {
            // we're authenticated, so do the save
        }
    }
