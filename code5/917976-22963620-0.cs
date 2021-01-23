    try
    {
        var credentials = new NetworkCredential(sUserName, sPassword);
        
        using (var connection = new LdapConnection(domainName))
        {
            connection.AuthType = AuthType.Kerberos 
            connection.Bind(credentials);
        }
        return true;
    }
    catch
    {
        //handle errors as you see fit
        return false;
    }
