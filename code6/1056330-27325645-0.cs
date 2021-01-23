    string fullUserName = null;
    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
    {
        using (UserPrincipal user = UserPrincipal.FindByIdentity(pc,User.Identity.Name))
        {
            if (user != null)
            {
                fullUserName = user.DisplayName;//this can be what ever you like 
            }
        }
    }
