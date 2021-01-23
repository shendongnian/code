        public void LogOut()
        {          
            var module = FederatedAuthentication.WSFederationAuthenticationModule;
            module.SignOut(false);
            var request = new SignOutRequestMessage(new Uri(module.Issuer), module.Realm);
            Response.Redirect(request.WriteQueryString());
        }
