        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if ( /*check table to see if user is allowed in*/)
            {
                HttpContext.Current.User = null;
            }
        }
