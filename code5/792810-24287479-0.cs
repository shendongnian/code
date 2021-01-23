    static void Main(string[] args)
    {
        foreach (string user in GetMemberNames("My Group", "domain.local"))
        {
            Console.WriteLine(user);
        }
        Console.ReadKey();
    }
    public static string[] GetMemberNames(string groupname, string domain)
    {
        using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
        using (GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupname))
        using (PrincipalSearchResult<Principal> results = group.GetMembers(true))
        {
            return results.OfType<UserPrincipal>().Select(u => u.SamAccountName).ToArray();
        }
    }
