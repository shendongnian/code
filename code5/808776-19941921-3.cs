    using System.DirectoryServices;
    
    using (var de = new DirectoryEntry("LDAP://DC=MYDOMAIN,DC=COM"))
    using (var ds = new DirectorySearcher(de))
    {
      ds.Filter = string.Format("(sAMAccountName={0})", HttpContext.Current.User.Identity.Name);
      ds.PropertiesToLoad.AddRange(new [] {
    			"sn",  // last name
    			"givenName",  // first name
    			"mail",  // email
    			"telephoneNumber",	// phone number
    			// etc - add other properties you need
    			});
      var res = ds.FindOne();
      
      foreach (string propName in res.Properties.PropertyNames)
      {
        ResultPropertyValueCollection valueCollection = res.Properties[propName];
        foreach (Object propertyValue in valueCollection)
        {
             Console.WriteLine("Property: " + propName + ": " + propertyValue.ToString());
        }
      }
    }
