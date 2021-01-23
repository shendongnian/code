    ...
    using System.DirectoryServices.Protocols;
    ...
    string server = "192.168.1.1";
    using (LdapConnection ldapConnection = new LdapConnection(server))
    {
        ldapConnection.AuthType = AuthType.Anonymous;
        SearchRequest request = new SearchRequest(null, "(objectclass=*)",
              SearchScope.Base, "defaultNamingContext");
        SearchResponse result = (SearchResponse)ldapConnection.SendRequest(request);
        if (result.Entries.Count == 1)
        {
            Console.WriteLine(result.Entries[0].Attributes["defaultNamingContext"][0]);
        }
    }
