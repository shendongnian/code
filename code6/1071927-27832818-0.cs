    try
    {
		//create results objects from search object 
		SearchResultCollection results = search.FindAll();
        //run through list, for each entry remove 'CN=' and add 'user' to list
        for (int i = 0; i < results.Count; i++)
        {
            DirectoryEntry de = results[i].GetDirectoryEntry();
            string user = de.Name.Replace("CN=", "");
            domainUsers.Add(user);
        }
    }
    catch(Excpetion e)
    {
        //add code here to process the error
        //after debugging, you may even decide to just swallow the exception 
        // and return an empty collection
    }
