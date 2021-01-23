    using (DirectoryEntry rootEntry = new DirectoryEntry(ConfigurationKeys.Ldap, string.Empty, string.Empty, AuthenticationTypes.None))
    {
        using (DirectorySearcher adSearch = new DirectorySearcher(rootEntry))
        {
            adSearch.SearchScope = SearchScope.Subtree;
            adSearch.PropertiesToLoad.Add("givenname");
            adSearch.PropertiesToLoad.Add("mail");
    
            adSearch.Filter = "(mail=myemail@mydomain.org)";
            SearchResult adSearchResult = adSearch.FindOne();
            // make sure the adSearchResult is not null
            // and the "givenName" property is not null (could be empty / null)
            if(adSearchResult != null && adSearchResult.Properties["givenName"] != null) 
            {
                // make sure the givenName property contains at least one string value
                if (adSearchResult.Properties["givenName"].Count > 0)
                {
                   string givenName = adSearchResult.Properties["givenName"][0].ToString();
                }
            }
        }
    }
