    public bool UserValid(string username, string password, bool useSSL)
    {
        bool userAuthenticated = false;
        var domainName = DomainName;
            
        if (useSSL)
        {
            domainName = domainName + ":636";
        }
        try
        {
            using (var ldap = new LdapConnection(domainName))
            {
                var networkCredential = new NetworkCredential(username, password, DomainName); // Uses DomainName without the ":636" at all times, SSL or not.
                ldap.SessionOptions.VerifyServerCertificate += VerifyServerCertificate;
                ldap.SessionOptions.SecureSocketLayer = useSSL;
                ldap.AuthType = AuthType.Negotiate;
                ldap.Bind(networkCredential);
            }
            // If the bind succeeds, we have a valid user/pass.
            userAuthenticated = true;
        }
        catch (LdapException ldapEx)
        {
            // Error Code 0x31 signifies invalid credentials, so return userAuthenticated as false.
            if (!ldapEx.ErrorCode.Equals(0x31))
            {
                throw;
            }
        }
        return userAuthenticated;
    }
    private bool VerifyServerCertificate(LdapConnection connection, X509Certificate certificate)
    {
        X509Certificate2 cert = new X509Certificate2(certificate);
        if (!cert.Verify())
        {
            // Could not validate potentially self-signed SSL certificate. Prompting user to install certificate themselves.
            X509Certificate2UI.DisplayCertificate(cert);
            // Try verifying again as the user may have allowed the certificate, and return the result.
            if (!cert.Verify())
            {
                throw new SecurityException("Could not verify server certificate. Make sure this certificate comes from a trusted Certificate Authority.");
            }
        }
        return true;
    }
