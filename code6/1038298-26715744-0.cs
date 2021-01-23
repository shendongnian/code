        protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            ForceLogoutIfSessionExpired();
        }
        private void ForceLogoutIfSessionExpired()
        {
            if (Context.Handler is IRequiresSessionState)
            {
                if (Request.IsAuthenticated)
                {
                    if (HttpContext.Current.Session["name"] == null)
                    {
                        AuthenticationHandler.SignOut(Response);
                        Response.Redirect(FormsAuthentication.LoginUrl, true);
                    }
                }
            }
