    DirectorySearcher searcher = new DirectorySearcher();
    DirectoryEntry rootEntry = new DirectoryEntry(_ldap, _loginName, _password, AuthenticationTypes.ReadonlyServer);
    
    searcher.SearchRoot = rootEntry;
    searcher.SearchScope = SearchScope.Subtree;
    searcher.Filter = "(&(sAMAccountName=" + filter.Split('\\')[1] + ")(objectClass=user))";
    searcher.PropertiesToLoad.Add("memberOf");
    searcher.PropertiesToLoad.Add("displayname");
    
    SearchResult sr = searcher.FindOne();
    DirectoryEntry userDirectoryEntry = result.GetDirectoryEntry();
    userDirectoryEntry.RefreshCache(new string[] { "tokenGroups" });
        
    foreach (byte[] byteEntry in userDirectoryEntry.Properties["tokenGroups"])
    {
       if (CompareByteArrays(byteEntry, objectSid))
       {
             isMember = true;
             break;
       }
    }
