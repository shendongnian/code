    DirectoryEntry entry = new DirectoryEntry("LDAP://" + Bous.DomainName, Bous.UserName, Bous.Password);
    DirectorySearcher mySearcher = new DirectorySearcher(entry);
    mySearcher.PageSize = 1000;   // <--- Important!
    mySearcher.Filter = ("(&(objectCategory=person)(objectClass=user))");
    
    foreach (SearchResult result in mySearcher.FindAll())
    {
         dr = dt.NewRow();
         ResultPropertyCollection myResultPropColl = result.Properties;
         dr[0] = myResultPropColl["samaccountname"][0].ToString() + "@" + Bous.DomainName;
         dt.Rows.Add(dr);
    }     
