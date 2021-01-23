    static List<string> GetUserEmailAddresses(string username, string domain)
    {
        using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domain))
        using (UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, username))
        {
            return ((DirectoryEntry)user.GetUnderlyingObject())
                .Properties["msExchShadowProxyAddresses"]
                .OfType<string>()
                .Select(s => s ?? string.Empty)
                .First()
                .Split(';')
                .Select(s => s.Trim())
                .Where(s => s.StartsWith("smtp:", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
