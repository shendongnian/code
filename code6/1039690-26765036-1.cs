    DirectoryEntry directoryEntry = new DirectoryEntry(ConnectionString, ProviderUserName, ProviderPassword, AuthenticationTypes.Secure);
     /******************************/
    
     DirectorySearcher search = new DirectorySearcher(directoryEntry);
     search.Filter = "(&(objectClass=user)(sAMAccountName=" + username + "))";
     search.CacheResults = false;
    
     SearchResultCollection allResults = search.FindAll();
     StringBuilder sb = new StringBuilder();
    
     foreach (SearchResult searchResult in allResults)
     {
         foreach (string propName in searchResult.Properties.PropertyNames)
         {
             ResultPropertyValueCollection valueCollection = searchResult.Properties[propName];
             foreach (Object propertyValue in valueCollection)
             {
                 sb.AppendLine(string.Format("<b>{0}</b> : <i>{1}</i> <br />", propName, propertyValue));
             }
         }
     }
    
     return sb.ToString();
