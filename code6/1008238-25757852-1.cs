    //Create a shortcut to the appropriate Windows domain
    PrincipalContext domainContext = new PrincipalContext(ContextType.Domain,
                                                          "myDomain");
     
    //Create a "user object" in the context
    using(UserPrincipal user = new UserPrincipal(domainContext))
    {
     //Specify the search parameters
     user.Name = "he*";
     
     //Create the searcher
     //pass (our) user object
     using(PrincipalSearcher pS = new PrincipalSearcher())
     {
      pS.QueryFilter = user;
     
      //Perform the search
      using(PrincipalSearchResult<Principal> results = pS.FindAll())
      {
       //If necessary, request more details
       Principal pc = results.ToList()[0];
       DirectoryEntry de = (DirectoryEntry)pc.GetUnderlyingObject();
      }
     }
    } 
    //Output first result of the test
    MessageBox.Show(de.Properties["mail"].Value.ToString());
