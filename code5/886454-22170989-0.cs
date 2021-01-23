    public List<LookupValues> FindBy(LdapSearchCriteria criteria)
    {
        List<LookupValues> usersMatchingCriteria = new List<LookupValues>();
        NetworkCredential credentials = new NetworkCredential(connectionDetails.UserName, connectionDetails.Password, connectionDetails.Domain);
        LdapDirectoryIdentifier directoryIdentifier = new LdapDirectoryIdentifier(connectionDetails.Server, connectionDetails.Port, false, false);
        using (LdapConnection connection = CreateConnection(directoryIdentifier))
        {
            connection.Bind(credentials);
            SearchRequest search = CreateSearchRequest(criteria);
            SearchResponse response = connection.SendRequest(search) as SearchResponse;
            foreach (SearchResultEntry entry in response.Entries)
            {
                LookupValues foundUser = GetUserDetailsFrom(entry);
                usersMatchingCriteria.Add(foundUser);
            }
        }
        return usersMatchingCriteria;
    }
