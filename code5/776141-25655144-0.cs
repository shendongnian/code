	private bool DoLogin(string userName, string password)
	{
		using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "DomainName.com")) {
			bool isValid = pc.ValidateCredentials(userName, password);
			if (isValid) {
			    // authenticated
                ...
                return true;
            }
            else {
                // invalid credentials
                ...
                return false;
            }
        }
    }
