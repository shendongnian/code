    public static bool CheckActiveDirectoryAccount(string account, string domain)
    {
        using (var pc = new PrincipalContext(ContextType.Domain, domain))
        {
            // Find a user
            UserPrincipal user = UserPrincipal.FindByIdentity(pc, account);
            if (user == null)
                return false;
            
            return true;
        }
    }
