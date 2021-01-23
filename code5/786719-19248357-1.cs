     public bool AuthenticateUser(string domainName, string userName,
      string password)
    {
      bool ret = false;
    
      try
      {
        DirectoryEntry de = new DirectoryEntry("LDAP://" + domainName,
                                               userName, password);
        DirectorySearcher dsearch = new DirectorySearcher(de);
        SearchResult results = null;
    
        results = dsearch.FindOne();
    
        ret = true;
      }
      catch
      {
        ret = false;
      }
    
      return ret;
    }
