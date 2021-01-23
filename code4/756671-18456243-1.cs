      protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User == null) return;
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return;
            if (!(HttpContext.Current.User.Identity is FormsIdentity)) return;
            var id = HttpContext.Current.User.Identity as FormsIdentity;
            var ticket = id.Ticket;
            var userData = ticket.UserData;
            var roles = userData.Split(new[] { ',' });
            HttpContext.Current.User = new GenericPrincipal(id, roles);
        }
