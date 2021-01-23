    public void init()
    {
    	_credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
    	_credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
    	_credentials.UserName.UserName = uname;
    	_credentials.UserName.Password = password;
    
    	IOrganizationService service = new OrganizationServiceProxy(new Uri(_organizationUri), null, credentials, null);
    }
