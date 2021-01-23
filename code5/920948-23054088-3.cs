            protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    if (authTicket.UserData == "OAuth") return;
                }
            }
