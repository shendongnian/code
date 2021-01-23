    // Get user name
    string userName = User.Identity.Name;
    var domainName = username.Split('\\')[0];
    // Getting domain
    var directoryContext = new DirectoryContext(DirectoryContextType.Domain, domainName);
    Domain domain = Domain.GetDomain(directoryContext);
    using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, domain.Name))
    {
        using (UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, userName))
        {
            if (user != null)
            {
                // Get details here
                var name = user.GivenName;
            }
        }
    }
