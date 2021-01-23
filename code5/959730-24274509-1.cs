        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            IPrincipal user = HttpContext.Current.User;
            if (user == null || !user.Identity.IsAuthenticated)
                return;
            var formsIdentity = HttpContext.Current.User.Identity as FormsIdentity;          
            var roles = formsIdentity.Ticket.UserData.Split(',');
            var gp = new GenericPrincipal(formsIdentity, roles);
            HttpContext.Current.User = gp;
        }
