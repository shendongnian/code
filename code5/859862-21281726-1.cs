        void OnPostAuthenticateRequest(object sender, EventArgs e)
        {
             // Get a reference to the current User 
            IPrincipal user = HttpContext.Current.User; 
         
            // If we are dealing with an authenticated forms authentication request         
            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms") 
            { 
                // Create custom Principal 
                var principal = new MyCustomPrincipal(user.Identity); 
             
                // Attach the Principal to HttpContext.User and Thread.CurrentPrincipal 
                HttpContext.Current.User = principal; 
                System.Threading.Thread.CurrentPrincipal = principal; 
            }
        } 
