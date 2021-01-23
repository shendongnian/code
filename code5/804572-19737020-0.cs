     override protected void OnInit(EventArgs e)
    {
        base.OnInit(e);
        //It appears from testing that the Request and Response both share the
        // same cookie collection.  If I set a cookie myself in the Reponse, it is
        // also immediately visible to the Request collection.  This just means that
        // since the ASP.Net_SessionID is set in the Session HTTPModule (which
        // has already run), thatwe can't use our own code to see if the cookie was
        // actually sent by the agent with the request using the collection. Check if
        // the given page supports session or not (this tested as reliable indicator
        // if EnableSessionState is true), should not care about a page that does
        // not need session
        if (Context.Session != null)
        {
            //Tested and the IsNewSession is more advanced then simply checking if
            // a cookie is present, it does take into account a session timeout, because
            // I tested a timeout and it did show as a new session
            if (Session.IsNewSession)
            {
                // If it says it is a new session, but an existing cookie exists, then it must
                // have timed out (can't use the cookie collection because even on first
                // request it already contains the cookie (request and response
                // seem to share the collection)
                string szCookieHeader = Request.Headers["Cookie"];
                if ((null != szCookieHeader) && (szCookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Redirect", "alert('Your session has timed out due to inactivity. Please start the test again'); window.location.reload()", true);
            }
        }
    }
