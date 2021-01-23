    string domainController = "192.168.0.150";
    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainController))
    {
        string userPrincipalName = "dotnettest" + "@" + domain;
        // validate the credentials
        bool isValid = pc.ValidateCredentials(userPrincipalName, "Ascertia 12");    
    }
