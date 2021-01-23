    DirectoryEntry dirEntry = new DirectoryEntry(path, userName, password, AuthenticationTypes.Secure);
    object obj = de.NativeObject;  // This will force the authentication
    
    // Search for the user's directory entry
    DirectorySearcher dirSearcher = new DirectorySearcher(dirEntry);
    dirSearcher.Filter = "(SAMAccountName=" + userName + ")";
    dirSearcher.PropertiesToLoad.Add("member");
    SearchResult searchResult = dirSearcher.FindOne();
    
    if (searchResult != null)
    {
        if (searchResult.Properties["member"] != null && searchResult.Properties["member"].Contains("commonusers"))
        {
            return true;
        }
    }
    
    return false;
