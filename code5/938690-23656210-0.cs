    public static bool ValidateDomainCredentials(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return false;
        }
        using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "mydomain"))
        {
               return pc.ValidateCredentials(username, password);
        }
    }
