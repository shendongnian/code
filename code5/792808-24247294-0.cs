    static void Main(string[] args)
    {
      /* Connection to Active Directory
       */
      string sFromWhere = "LDAP://SRVENTR2:389/dc=societe,dc=fr";
      DirectoryEntry deBase = new DirectoryEntry(sFromWhere, "societe\\administrateur", "test.2011");
    
      /* To find all the users member of groups "Grp1"  :
       * Set the base to the groups container DN; for example root DN (dc=societe,dc=fr) 
       * Set the scope to subtree
       * Use the following filter :
       * (member:1.2.840.113556.1.4.1941:=CN=Grp1,OU=MonOu,DC=X)
       */
      DirectorySearcher dsLookFor = new DirectorySearcher(deBase);
      dsLookFor.Filter = "(&(memberof:1.2.840.113556.1.4.1941:=CN=Grp1,OU=MonOu,DC=societe,DC=fr)(objectCategory=user))";
      dsLookFor.SearchScope = SearchScope.Subtree;
      dsLookFor.PropertiesToLoad.Add("cn");
      dsLookFor.PropertiesToLoad.Add("samAccountName");  
    
      SearchResultCollection srcUsers = dsLookFor.FindAll();
    
      /* Just show each user
       */
      foreach (SearchResult srcUser in srcUsers)
      {
        Console.WriteLine("{0}", srcUser.Path);
        Console.WriteLine("{0}", srcUser.Properties["samAccountName"][0]);
      }
    
      Console.ReadLine();
    }
