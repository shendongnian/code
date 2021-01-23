    ...
    // Here is a list of SIDs of users we want to find (initialized somewhere above)
    List<string> userSids;
    // List of sample results.
    List<string> loadedUsers = new List<string>();
    using (DirectorySearcher searcher = new DirectorySearcher(new DirectoryEntry("GC://dc2.domain2.domain1.local")))
    {
        StringBuilder filterStringBuilder = new StringBuilder();
        // Just create a single LDAP query for all user SIDs
        filterStringBuilder.Append("(&(objectClass=user)(|");
        foreach (string userSid in users)
        {
            filterStringBuilder.AppendFormat("({0}={1})", "objectSid", userSid);
        }
        filterStringBuilder.Append("))");
        searcher.PageSize = 1000; // Very important to have it here. Otherwise you'll get only 1000 at all. Please refere to DirectorySearcher documentation
        searcher.Filter = filterStringBuilder.ToString();
        // We do not want to go beyond GC
        searcher.ReferralChasing = ReferralChasingOption.None;
        searcher.PropertiesToLoad.AddRange(
            new[] { "DistinguishedName" });
        SearchResultCollection results = searcher.FindAll();
        foreach (SearchResult searchResult in results)
        {
            string distinguishedName = searchResult.Properties["DistinguishedName"][0].ToString();
            loadedUsers.Add(distinguishedName);
        }
    }
    ...
