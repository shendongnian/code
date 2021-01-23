    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain)
    {
        if (pc.ValidateCredentials(username, password))
        {
            /* Check group membership */
        }
    }
