    using (var ctx = new PrincipalContext(
        ContextType.Domain,
        host,
        rootDn,
        ContextOptions.ServerBind | ContextOptions.Negotiate | ContextOptions.SecureSocketLayer,
        username,
        password))
    using (var user = UserPrincipal.FindByIdentity(ctx, IdentityType.Guid, objectGuid.ToString()))
    {
        if (user != null)
        {
            user.UnlockAccount();
        }
        else
        {
            // user not found
        }
    }
