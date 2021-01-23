    public static bool IsUserGroupMember(string userName, string groupName)
    {
        using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
        using (UserPrincipal user = UserPrincipal.FindByIdentity(context, userName))
        using (PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups())
        {
            return groups.OfType<GroupPrincipal>().Any(g => g.Name.Equals(groupName, StringComparison.OrdinalIgnoreCase));
        }
    }
