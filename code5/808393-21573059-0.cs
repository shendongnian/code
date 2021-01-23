    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e)
            {
                //must check if user is authenticated (this method can be called before authentication) 
                if (Context.User.Identity.IsAuthenticated && Context.Session != null && Context.Session["IsLogged"] == null)
                {
                   Context.Session.Add("YourKey", YourData);
                   Context.Session.Add("IsLogged", true);
                }
                    
            }
