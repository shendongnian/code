     DirectoryEntry searchRoot = new DirectoryEntry("LDAP://"+lblDomain.Text);
     DirectorySearcher search = new DirectorySearcher(searchRoot);
     search.Filter = "(&(objectClass=computer)(name=" + host + "))";
     search.PropertiesToLoad.Add("managedBy");
     search.PropertiesToLoad.Add("distinguishedName");
     search.PropertiesToLoad.Add("cn");
     SearchResultCollection groups = search.FindAll();
     foreach (SearchResult sr in groups)
     {
      if (sr.Properties["managedBy"].Count > 0)
      {
          lblManagedBy.Text=(sr.Properties["managedBy"][0].ToString());
      }
      else
      {
         lblManagedBy.Text = "No owner specified in ManagedBy";
      }
    }
