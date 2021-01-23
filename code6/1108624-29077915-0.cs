        private void PostAuthenticateRequest(object sender, EventArgs e)
        {
            var ctx = HttpContext.Current;
            if (ctx.Request.IsAuthenticated)
            {
                var principal = ctx.User;
                var formsIdentity = principal.Identity as FormsIdentity;
                if (formsIdentity != null)
                {
                    var username = formsIdentity.Name;
                    var domain = "mydomain.com";
                    var fullyQualifiedUsername = username + "@" + domain;
                    var windowsIdentity = new WindowsIdentity(fullyQualifiedUsername);
                    var windowsPrincipal = new WindowsPrincipal(windowsIdentity);
                    Thread.CurrentPrincipal = ctx.User = windowsPrincipal;
                }
            }
        }
