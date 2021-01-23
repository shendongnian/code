        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var newUser = (IPrincipal)DependencyResolver.Current.GetService(typeof(IPrincipal));
            HttpContext.Current.User = newUser;
        }
