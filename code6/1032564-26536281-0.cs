    bool authenticated;
    using (PrincipalContext domainContext = new PrincipalContext(ContextType.Domain, domain))
    {
        authenticated = domainContext.ValidateCredentials(username, password);
    }
