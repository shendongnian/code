        public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        {
            if (incomingPrincipal.Identity.IsAuthenticated)
            {
                //Check here if the authenticated user has access to this system
                //using the user repository and if so add more claims to the token
            }
            return base.Authenticate(resourceName, incomingPrincipal);
        }
