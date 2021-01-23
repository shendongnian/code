    	private static DirectoryEntry forestlocal = new DirectoryEntry(LocalGCUri, LocalGCUsername, LocalGCPassword);
    	private DirectorySearcher localSearcher = new DirectorySearcher(forestlocal);
    	
    	 public List<string> GetAllUsers() 
        {
            List<string> users = new List<string>();
            localSearcher.SizeLimit = 10000;
            localSearcher.PageSize = 250;
            string localFilter = string.Format(@"(&(objectClass=user)(objectCategory=person)(!(objectClass=contact))(msRTCSIP-PrimaryUserAddress=*))");
            localSearcher.Filter = localFilter;
            
            SearchResultCollection localForestResult;
           
            try
            {
                localForestResult = localSearcher.FindAll();
                if (resourceForestResult != null) 
                {
                    foreach (SearchResult result in localForestResult) 
                    {
                        if (result.Properties.Contains("mail"))
                            users.Add((string)result.Properties["mail"][0]);
                    }
                   
                }
            }
            catch (Exception ex) 
            {
            }
            return users;
        }
