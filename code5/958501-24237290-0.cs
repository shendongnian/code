        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity formID =  
                             (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = formID.Ticket;
                        //get stored user data, in this case "user role"
                        string[] roles = new string[1] { ticket.UserData };
                        HttpContext.Current.User = new GenericPrincipal(formID, roles);
                    }
                }
            }
        }
