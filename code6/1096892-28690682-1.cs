    using System.DirectoryServices;
    ....
    bool userOk = false;
    string realName = string.Empty;
    
    using (DirectoryEntry directoryEntry = 
       new DirectoryEntry"LDAP://192.168.1.1/DC=ad,DC=local", name, password))
    {
        using (DirectorySearcher searcher = new DirectorySearcher(directoryEntry))
        {
            searcher.Filter = "(samaccountname=" + name + ")";
            searcher.PropertiesToLoad.Add("displayname");
            SearchResult adsSearchResult = searcher.FindOne();
            if (adsSearchResult != null)
            {
                if (adsSearchResult.Properties["displayname"].Count == 1)
                {   
                    realName = (string)adsSearchResult.Properties["displayname"][0];
                }
                userOk = true;
            }
        }
    }	
