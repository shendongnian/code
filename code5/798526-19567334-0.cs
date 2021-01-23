    using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, dc))
    {
        using (GroupPrincipal p = GroupPrincipal.FindByIdentity(ctx, group))
        {
            using (UserPrincipal u = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, user))
            {
                return p.GetMembers(true).Contains(u);
            }
        }
    }
