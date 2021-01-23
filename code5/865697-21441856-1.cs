    static List<string> GetUserEmailAddresses(string username, string domain)
    {
        using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domain))
        using (UserPrincipal user = UserPrincipal.FindByIdentity(domainContext, username))
        {
            return ((DirectoryEntry)user.GetUnderlyingObject())
                .Properties["msExchShadowProxyAddresses"]
                .OfType<string>()
                .Where(s => !string.IsNullOrWhiteSpace(s) && s.StartsWith("smtp:", StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
