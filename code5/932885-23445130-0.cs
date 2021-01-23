         List<string> list = GetMail(filter);
  .
      List<string> GetMail(string SearchFilter)
      {
         List<string> MailAddresses = new List<string>();
          using (DirectorySearcher directorySearcher = new DirectorySearcher())
          {
          directorySearcher.Filter = SearchFilter;
          SearchResultCollection resultCollection = directorySearcher.FindAll();
    
         foreach (SearchResult searchResult in resultCollection)
          {
             try
             {
                MailAddresses.Add(searchResult.Properties["mail"][0].ToString());
             }
             catch {
                    //Maybe fill a list of errors here.
                   }
          } 
      }
         return MailAddresses;
      }
