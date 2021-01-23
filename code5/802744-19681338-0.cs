    PrincipalContext pc = new PrincipalContext(ContextType.Domain, domainName);
    try
    {
         isValid = pc.ValidateCredentials(login, password);
    }
    finally
    {
         pc.Dispose();
    }
