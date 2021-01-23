     using (LdapConnection con = new LdapConnection(new LdapDirectoryIdentifier(ConfigReader.ADServer, 636)))
    {
        con.SessionOptions.SecureSocketLayer = true;
        con.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback(ServerCallback);
        con.Credential = new NetworkCredential(UserDN, UserPwd);
        con.AuthType = AuthType.Basic;
        con.Bind();
        **con.SendRequest(new SearchRequest(targetLocation, "(objectClass=*)", System.DirectoryServices.Protocols.SearchScope.Subtree, null));**
    }
