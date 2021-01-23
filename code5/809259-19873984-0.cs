    using (DirectoryEntry entry = new DirectoryEntry("LDAP://<your-ad-server-name>/dc=<domain-name-part>,dc=<domain-name-part>",
         "Administrator", "Your Secure Password", AuthenticationTypes.Secure))
    {
      using (DirectorySearcher adSearcher = new DirectorySearcher(entry))
      {
        string computerName = "computer01";
        adSearcher.Filter = "(&(objectClass=computer)(cn=" + computerName + "))";
        adSearcher.SearchScope = SearchScope.Subtree;
        adSearcher.PropertiesToLoad.Add("description");
        SearchResult searchResult = adSearcher.FindOne();
        Console.Out.WriteLine(searchResult.GetDirectoryEntry().Properties["description"].Value);
      }
    }
