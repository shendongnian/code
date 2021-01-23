    public static List<string> DomainUsers
    {
        get
        {
            List<string> users = new List<string>();
    
            using (PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "domain"))
            {
                // find user by display name
                UserPrincipal user = new UserPrincipal(ctx);
                PrincipalSearcher search = new PrincipalSearcher(user);
    
                search.FindAll().Cast<UserPrincipal>().ToList().ForEach(u => users.Add(u.SamAccountName));
            }
            return users;
        }
    }
    /// <summary>
    /// Gets all associated group names for current user on the current domain
    /// </summary>
    /// <returns></returns>
    public static List<string> GetGroupNames(string username)
    {
        var pc = new PrincipalContext(ContextType.Domain, "domain");
        var src = UserPrincipal.FindByIdentity(pc, username).GetGroups(pc);
        var result = new List<string>();
        src.ToList().ForEach(sr => result.Add(sr.SamAccountName));
        return result;
    }
    public static bool UserBelongsToGroup(string group)
    {
        PrincipalContext pc = new PrincipalContext((Environment.UserDomainName == Environment.MachineName ? ContextType.Machine : ContextType.Domain), Environment.UserDomainName);
        GroupPrincipal gp = GroupPrincipal.FindByIdentity(pc, group);
        UserPrincipal up = UserPrincipal.FindByIdentity(pc, Environment.UserName);
        return up.IsMemberOf(gp);
    }
