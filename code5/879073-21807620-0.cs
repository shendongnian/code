        public static int SetAuthCookie(this HttpResponseBase responseBase, User user, bool rememberMe)
        {
            // Initialize Session Ticket
            var authTicket = new FormsAuthenticationTicket(1
                , user.Email
                , DateTime.Now
                , DateTime.Now.AddHours(30)
                , rememberMe
                , JsonConvert.SerializeObject(new {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id
                })
                , FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            if (authTicket.IsPersistent)
                authCookie.Expires = authTicket.Expiration;
            responseBase.Cookies.Add(authCookie);
            return encTicket.Length;
        }
        public static void VerifyAuthCookie(HttpContext context)
        {
            HttpCookie authCookie = context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
                return;
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (authTicket == null)
                return;
            if (authTicket.Expired)
                return;
            User user = !string.IsNullOrEmpty(authTicket.UserData) ? JsonConvert.DeserializeObject<User>(authTicket.UserData) : null;
            if (user == null)
                return;
            // Create an Identity object
            UserIdentity id = new UserIdentity(user, authTicket);
            
            // This principal will flow throughout the request.
            GenericPrincipal principal = new GenericPrincipal(id, new [] { "User" });
            context.User = principal;
}
